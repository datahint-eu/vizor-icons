using Microsoft.AspNetCore.Components;

namespace Vizor.Icons.Bootstrap;

public struct IconData
{
	public IconData(string svgContent, string xmlns, string width, string height, string fill, string cssClass, string viewBox)
	{
		SvgContent = svgContent;
		Xmlns = xmlns;
		Width = width;
		Height = height;
		Fill = fill;
		Class = cssClass;
		ViewBox = viewBox;
	}

	public string SvgContent { get; }
	public string Xmlns { get; }
	public string Width { get; }
	public string Height { get; }
	public string Fill { get; }
	public string Class { get; }
	public string ViewBox { get; }
}

public static class IconDataExtensions
{
	public static RenderFragment Render(this IconData data, string? width, string? height, string? fill, string? cssClass, string? viewBox) => builder =>
	{
		builder.OpenElement(0, "svg");

		builder.AddAttribute(1, "xmlns", data.Xmlns);
		builder.AddAttribute(2, "width", width ?? data.Width);
		builder.AddAttribute(3, "height", height ?? data.Height);
		builder.AddAttribute(4, "fill", fill ?? data.Fill);
		builder.AddAttribute(5, "viewBox", viewBox ?? data.ViewBox);

		if (string.IsNullOrWhiteSpace(cssClass))
		{
			builder.AddAttribute(6, "class", data.Class);
		}
		else
		{
			builder.AddAttribute(6, "class", data.Class + ' ' + cssClass);
		}

		builder.AddMarkupContent(7, data.SvgContent);

		builder.CloseElement();
	};
}