using Microsoft.AspNetCore.Components;
using System.Text;

namespace NAMESPACE;

#nullable enable

public struct IconData
{
	public IconData(string svgContent, string? xmlns = null,
		string? width = null, string? height = null, string? fill = null, string? cssClass = null, string? viewBox = null,
		string? stroke = null, string? strokeWidth = null, string? strokeLineCap = null, string? strokeLineJoin = null)
	{
		SvgContent = svgContent;
		Xmlns = xmlns;
		Width = width;
		Height = height;
		Fill = fill;
		Class = cssClass;
		ViewBox = viewBox;

		Stroke = stroke;
		StrokeWidth = strokeWidth;
		StrokeLineCap = strokeLineCap;
		StrokeLineJoin = strokeLineJoin;
	}

	public string SvgContent { get; }
	public string? Xmlns { get; }
	public string? Width { get; }
	public string? Height { get; }
	public string? Fill { get; }
	public string? Class { get; }
	public string? ViewBox { get; }
	public string? Stroke { get; }
	public string? StrokeWidth { get; }
	public string? StrokeLineCap { get; }
	public string? StrokeLineJoin { get; }
}

public static class IconDataExtensions
{
	public static RenderFragment Render(this IconData data, string? width, string? height, string? fill, string? cssClass, string? viewBox) => builder =>
	{
		builder.OpenElement(0, "svg");

		if (data.Xmlns != null)
			builder.AddAttribute(1, "xmlns", data.Xmlns);

		if (data.Width != null || width != null)
			builder.AddAttribute(2, "width", width ?? data.Width);

		if (data.Height != null || height != null)
			builder.AddAttribute(3, "height", height ?? data.Height);

		if (data.Fill != null || fill != null)
			builder.AddAttribute(4, "fill", fill ?? data.Fill);

		if (data.ViewBox != null || viewBox != null)
			builder.AddAttribute(5, "viewBox", viewBox ?? data.ViewBox);

		if (data.Stroke != null)
			builder.AddAttribute(6, "stroke", data.Stroke);

		if (data.StrokeWidth != null)
			builder.AddAttribute(7, "stroke-width", data.StrokeWidth);

		if (data.StrokeLineCap != null)
			builder.AddAttribute(8, "stroke-linecap", data.StrokeLineCap);

		if (data.StrokeLineJoin != null)
			builder.AddAttribute(9, "stroke-linejoin", data.StrokeLineJoin);

		if (string.IsNullOrWhiteSpace(cssClass))
		{
			builder.AddAttribute(10, "class", data.Class);
		}
		else
		{
			builder.AddAttribute(10, "class", data.Class + ' ' + cssClass);
		}

		builder.AddMarkupContent(20, data.SvgContent);

		builder.CloseElement();
	};

	public static string RenderAsString(this IconData data, string? width, string? height, string? fill, string? cssClass, string? viewBox)
	{
		var sb = new StringBuilder();

		sb.Append("<svg");

		if (data.Xmlns != null) {
			sb.Append(" xmlns=\"");
			sb.Append(data.Xmlns);
			sb.Append('"');
		}

		if (data.Width != null || width != null)
		{
			sb.Append(" width=\"");
			sb.Append(width ?? data.Width);
			sb.Append('"');
		}

		if (data.Height != null || height != null)
		{
			sb.Append(" height=\"");
			sb.Append(height ?? data.Height);
			sb.Append('"');
		}

		if (data.Fill != null || fill != null)
		{
			sb.Append(" fill=\"");
			sb.Append(fill ?? data.Fill);
			sb.Append('"');
		}

		if (data.ViewBox != null || viewBox != null)
		{
			sb.Append(" viewBox=\"");
			sb.Append(viewBox ?? data.ViewBox);
			sb.Append('"');
		}

		if (data.Stroke != null)
		{
			sb.Append(" stroke=\"");
			sb.Append(data.Stroke);
			sb.Append('"');
		}

		if (data.StrokeWidth != null)
		{
			sb.Append(" stroke-width=\"");
			sb.Append(data.StrokeWidth);
			sb.Append('"');
		}

		if (data.StrokeLineCap != null)
		{
			sb.Append(" stroke-linecap=\"");
			sb.Append(data.StrokeLineCap);
			sb.Append('"');
		}

		if (data.StrokeLineJoin != null)
		{
			sb.Append(" stroke-linejoin=\"");
			sb.Append(data.StrokeLineJoin);
			sb.Append('"');
		}

		sb.Append(" class=\"");
		if (string.IsNullOrWhiteSpace(cssClass))
		{
			sb.Append(data.Class);
		}
		else
		{
			sb.Append(data.Class + ' ' + cssClass);
		}
		sb.Append("\">");

		sb.Append(data.SvgContent);
		sb.Append("</svg>");

		return sb.ToString();
	}
}

#nullable disable