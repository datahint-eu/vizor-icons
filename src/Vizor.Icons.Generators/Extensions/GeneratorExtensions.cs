using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Vizor.Icons.Generators.Extensions;

public static class GeneratorExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cds"></param>
    /// <param name="attributeName">Attribute name WITHOUT the Attribute suffix</param>
    /// <returns></returns>
    public static bool HasAttribute(this ClassDeclarationSyntax? cds, string attributeName)
    {
        if (cds is not null && cds.AttributeLists.Count > 0)
        {
            var syntaxAttributes = cds.AttributeLists.SelectMany(e => e.Attributes)
                .Where(e => e.Name.NormalizeWhitespace().ToFullString() == attributeName);

            return syntaxAttributes.Any();
        }
        return false;
    }

	public static string? GetNamespace(this ClassDeclarationSyntax? cds)
	{
		if (cds == null)
			return null;

		foreach (var ancestor in cds.Ancestors())
		{
			if (ancestor is NamespaceDeclarationSyntax nds)
				return nds.Name.ToFullString().TrimEnd();
			else if (ancestor is FileScopedNamespaceDeclarationSyntax fnds)
				return fnds.Name.ToFullString().TrimEnd();
		}

		return null;
	}

	public static Dictionary<string, string> GetClassEditorKeyValues(this ClassDeclarationSyntax? cds)
	{
		var dict = new Dictionary<string, string>();

		if (cds is not null && cds.AttributeLists.Count > 0)
		{
			foreach (var editorAttrib in cds.AttributeLists.SelectMany(e => e.Attributes).Where(e => e.Name.NormalizeWhitespace().ToFullString() == "Editor"))
			{
				var attribChildren = editorAttrib.ChildNodes().ToList();
				if (attribChildren.Count > 1 && attribChildren[1] is AttributeArgumentListSyntax als)
				{
					// 0 = IdentifierNameSyntax
					// 1 = AttributeArgumentListSyntax

					var args = als.ChildNodes().OfType<AttributeArgumentSyntax>().Select(n => n.GetText().ToString()).Select(s => s.Substring(1, s.Length - 2)).ToList();
					if (args.Count == 2)
					{
						dict.Add(args[0], args[1]);
					}
				}
			}
		}

		return dict;
	}
}
