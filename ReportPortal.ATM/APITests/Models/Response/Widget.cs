using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APITests.Models.Response;

public class Widget
{
    [JsonPropertyName("widgetName")]
    public string? WidgetName { get; set; }

    [JsonPropertyName("widgetId")]
    public int? WidgetId { get; set; }

    [JsonPropertyName("widgetType")]
    public string? WidgetType { get; set; }

    [JsonPropertyName("widgetSize")]
    public WidgetSize? WidgetSize { get; set; }

    [JsonPropertyName("widgetPosition")]
    public WidgetPosition? WidgetPosition { get; set; }

    [JsonPropertyName("widgetOptions")]
    public Dictionary<string, object>? WidgetOptions { get; set; }
}