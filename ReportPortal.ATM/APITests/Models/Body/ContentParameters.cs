using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APITests.Models.Body;

public class ContentParameters
{
    [JsonPropertyName("contentFields")]
    public List<string>? ContentFields { get; set; }
    [JsonPropertyName("itemsCount")]
    public string? ItemsCount { get; set; }
    [JsonPropertyName("widgetOptions")]
    public WidgetOptions? WidgetOptions { get; set; }
}