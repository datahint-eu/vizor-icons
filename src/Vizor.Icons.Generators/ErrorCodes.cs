using Microsoft.CodeAnalysis;

namespace Vizor.Icons.Generators;

internal static class ErrorCodes
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("MicrosoftCodeAnalysisReleaseTracking", "RS2008:Enable analyzer release tracking")]
	internal static readonly DiagnosticDescriptor NamespaceNotFound = new(
		id: "VI0002",
		title: "Failed to detect namespace",
		messageFormat: "Failed to detect namespace of class class '{0}'",
		category: "VizorGen",
		defaultSeverity: DiagnosticSeverity.Error,
		isEnabledByDefault: true,
		description: "");

	[System.Diagnostics.CodeAnalysis.SuppressMessage("MicrosoftCodeAnalysisReleaseTracking", "RS2008:Enable analyzer release tracking")]
	internal static readonly DiagnosticDescriptor InternalError = new(
		id: "VI0004",
		title: "Internal error",
		messageFormat: "Error while generating renderer for class '{0}'",
		category: "VizorGen",
		defaultSeverity: DiagnosticSeverity.Error,
		isEnabledByDefault: true,
		description: "");

	[System.Diagnostics.CodeAnalysis.SuppressMessage("MicrosoftCodeAnalysisReleaseTracking", "RS2008:Enable analyzer release tracking")]
	internal static readonly DiagnosticDescriptor InvalidSourcePathWarning = new(
		id: "VI0005",
		title: "Invalid source path",
		messageFormat: "Source path '{0}' does not exist",
		category: "VizorGen",
		DiagnosticSeverity.Error,
		isEnabledByDefault: true,
		description: "");
}
