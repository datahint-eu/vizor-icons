﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Vizor.Icons.Generators.Extensions;

namespace Vizor.Icons.Generators;

[Generator(LanguageNames.CSharp)]
public class IconGenerator : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
#if DEBUG
		// uncomment if you want to debug the generator
		//if (!Debugger.IsAttached) Debugger.Launch();
#endif
		var classProvider = context.SyntaxProvider
			.CreateSyntaxProvider(
				predicate: static (s, _) => IsSyntaxTargetForGenerationClass(s),
				transform: static (ctx, _) => GetSemanticTargetForGenerationClass(ctx))
			.Where(static m => m is not null)!;

		var compilationAndClasses = context.CompilationProvider.Combine(classProvider.Collect());

		context.RegisterSourceOutput(compilationAndClasses,
			static (spc, source) => ExecuteForClass(source.Left, source.Right, spc));
	}

	private static bool IsSyntaxTargetForGenerationClass(SyntaxNode s)
	{
		if (s is ClassDeclarationSyntax cds && cds.HasAttribute("Editor"))
			return true;

		return false;
	}

	private static ClassDeclarationSyntax? GetSemanticTargetForGenerationClass(GeneratorSyntaxContext ctx)
	{
		return ctx.Node as ClassDeclarationSyntax;
	}

	private static void ExecuteForClass(Compilation comp, ImmutableArray<ClassDeclarationSyntax?> classes, SourceProductionContext context)
	{
		try
		{
			foreach (var cls in classes)
			{
				if (cls == null)
					continue;

				// get the namespace
				var ns = cls.GetNamespace();
				if (ns == null)
				{
					context.ReportDiagnostic(Diagnostic.Create(ErrorCodes.NamespaceNotFound, null, cls.Identifier.Text));
					return;
				}

				var dict = cls.GetClassEditorKeyValues();
				if (dict.TryGetValue("generator", out var generator))
				{
					switch (generator)
					{
						case "svg-icon":
							GenerateSvgIconClass(ns, cls, context, dict);
							break;
						case "font-icon":
							GenerateFontIconClass(ns, cls, context, dict);
							break;
					}
				}

			}
		}
		catch (Exception ex)
		{
			context.ReportDiagnostic(Diagnostic.Create(ErrorCodes.InternalError, null, ex.Message));
		}
	}

	private static void GenerateFontIconClass(string ns, ClassDeclarationSyntax cls, SourceProductionContext context, Dictionary<string, string> dict)
	{
		// find out the location of the file
		var projectDir = Path.GetDirectoryName(cls.GetLocation().SourceTree?.FilePath);

		var cssFile = Path.Combine(projectDir, dict["path"]);
		var iconPrefix = dict["css-prefix"];
		var cssClassPrefix = dict["class-prefix"];

		if (!File.Exists(cssFile))
		{
			context.ReportDiagnostic(Diagnostic.Create(ErrorCodes.InvalidSourcePathWarning, Location.None, cssFile));
			return;
		}

		// generate the partial class
		var sb = new StringBuilder();
		sb.AppendLine($"namespace {ns};");
		sb.AppendLine($"public static partial class {cls.Identifier.Text}");
		sb.AppendLine("{");

		var prefixLen = iconPrefix.Length;
		foreach (var line in File.ReadAllLines(cssFile))
		{
			if (!line.StartsWith(iconPrefix))
				continue;

			var colonIndex = line.IndexOf(':');
			var iconValue = line.Substring(prefixLen, colonIndex - prefixLen);

			var iconName = iconValue.GetIconName();
			sb.AppendLine($"\tpublic const string {iconName} = \"{cssClassPrefix}{iconValue}\";");
		}

		sb.AppendLine("}");

		context.AddSource($"{cls.Identifier.Text}.generated.cs", sb.ToString());

		// write debug output if required
		if (dict.ContainsKey("debug-output"))
		{
			File.WriteAllText(Path.Combine(projectDir, dict["debug-output"]), sb.ToString());
		}
	}

	private static void GenerateSvgIconClass(string ns, ClassDeclarationSyntax cls, SourceProductionContext context, Dictionary<string, string> dict)
	{
		// find out the location of the file
		var projectDir = Path.GetDirectoryName(cls.GetLocation().SourceTree?.FilePath);

		// get parameters
		var sourceDir = Path.Combine(projectDir, dict["path"]);

		if (!Directory.Exists(sourceDir))
		{
			context.ReportDiagnostic(Diagnostic.Create(ErrorCodes.InvalidSourcePathWarning, Location.None, sourceDir));
			return;
		}

		// generate an IconData class in the correct namespace
		GenerateIconDataClass(context, projectDir, ns);

		// generate the partial class
		var sb = new StringBuilder();
		sb.AppendLine("using Microsoft.AspNetCore.Components;");
		sb.AppendLine($"namespace {ns};");
		sb.AppendLine($"public partial class {cls.Identifier.Text}");
		sb.AppendLine("{");

		foreach (var filename in Directory.GetFiles(sourceDir, "*.svg"))
		{
			var iconName = filename.GetIconName();

			var svg = new XmlDocument();
			svg.Load(filename);

			// extract the attributes
			var xmlns = svg.DocumentElement.GetAttribute("xmlns");
			var width = svg.DocumentElement.GetAttribute("width");
			var height = svg.DocumentElement.GetAttribute("height");
			var fill = svg.DocumentElement.GetAttribute("fill");
			var cssClass = svg.DocumentElement.GetAttribute("class");
			var viewBox = svg.DocumentElement.GetAttribute("viewBox");
			
			var stroke = svg.DocumentElement.GetAttribute("stroke");
			var strokeWidth = svg.DocumentElement.GetAttribute("stroke-width");
			var strokeLineCap = svg.DocumentElement.GetAttribute("stroke-linecap");

			var strokeLineJoin = svg.DocumentElement.GetAttribute("stroke-linejoin");
			

			// extract all the children in 1 single line + double quote
			var content = svg.DocumentElement.InnerXml.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("\"", "\"\"");

			sb.Append($"\tpublic static readonly IconData {iconName} = new IconData(svgContent: @\"{content}\"");
			if (!string.IsNullOrWhiteSpace(xmlns))
				sb.Append($", xmlns: \"{xmlns}\"");
			if (!string.IsNullOrWhiteSpace(width))
				sb.Append($", width: \"{width}\"");
			if (!string.IsNullOrWhiteSpace(height))
				sb.Append($", height: \"{height}\"");
			if (!string.IsNullOrWhiteSpace(fill))
				sb.Append($", fill: \"{fill}\"");
			if (!string.IsNullOrWhiteSpace(cssClass))
				sb.Append($", cssClass: \"{cssClass}\"");
			if (!string.IsNullOrWhiteSpace(viewBox))
				sb.Append($", viewBox: \"{viewBox}\"");
			if (!string.IsNullOrWhiteSpace(stroke))
				sb.Append($", stroke: \"{stroke}\"");
			if (!string.IsNullOrWhiteSpace(strokeWidth))
				sb.Append($", strokeWidth: \"{strokeWidth}\"");
			if (!string.IsNullOrWhiteSpace(strokeLineCap))
				sb.Append($", strokeLineCap: \"{strokeLineCap}\"");
			if (!string.IsNullOrWhiteSpace(strokeLineJoin))
				sb.Append($", strokeLineJoin: \"{strokeLineJoin}\"");

			sb.AppendLine(");");
		}

		sb.AppendLine("}");

		context.AddSource($"{cls.Identifier.Text}.generated.cs", sb.ToString());

		// write debug output if required
		if (dict.ContainsKey("debug-output"))
		{
			File.WriteAllText(Path.Combine(projectDir, dict["debug-output"]), sb.ToString());
		}
	}

	private static void GenerateIconDataClass(SourceProductionContext context, string projectDir, string ns)
	{
		var file = Path.Combine(projectDir, "../IconData.cs");
		if (!File.Exists(file))
		{
			context.ReportDiagnostic(Diagnostic.Create(ErrorCodes.InvalidSourcePathWarning, Location.None, file));
			return;
		}

		var fileContent = File.ReadAllText(file).Replace("NAMESPACE", ns);

		context.AddSource($"IconData.generated.cs", fileContent);
	}
}