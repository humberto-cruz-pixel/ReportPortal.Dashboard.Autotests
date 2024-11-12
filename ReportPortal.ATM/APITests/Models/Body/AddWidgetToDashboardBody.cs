using APITests.Models.Response;
using System.Text.Json.Serialization;

namespace APITests.Models.Body;

public class AddWidgetToDashboardBody
{
    [JsonPropertyName("addWidget")]
    public AddWidget addWidget { get; set; }
}

public class AddWidget
{
    [JsonPropertyName("widgetId")]
    public int? WidgetId { get; set; }
    [JsonPropertyName("widgetName")]
    public string WidgetName { get; set; }
    [JsonPropertyName("widgetOptions")]
    public WidgetOptions WidgetOptions { get; set; }
    [JsonPropertyName("widgetPosition")]
    public WidgetPosition WidgetPosition { get; set; }
    [JsonPropertyName("widgetSize")]
    public WidgetSize WidgetSize { get; set; }
    [JsonPropertyName("widgetType")]
    public string WidgetType { get; set; }
}