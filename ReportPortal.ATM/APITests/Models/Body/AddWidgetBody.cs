using System.Text.Json.Serialization;

namespace APITests.Models.Body;

public class AddWidgetBody
{
    [JsonPropertyName("widgetType")]
    public string WidgetType { get; set; }
    [JsonPropertyName("contentParameters")]
    public ContentParameters ContentParameters { get; set; }
    [JsonPropertyName("filters")]
    public List<Filter> Filters { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("filterIds")]
    public List<string> FilterIds { get; set; }
}

public class ContentParameters
{
    [JsonPropertyName("contentFields")]
    public List<string> ContentFields { get; set; }
    [JsonPropertyName("itemsCount")]
    public string ItemsCount { get; set; }
    [JsonPropertyName("widgetOptions")]
    public WidgetOptions WidgetOptions { get; set; }
}

public class WidgetOptions
{
    [JsonPropertyName("zoom")]
    public bool Zoom { get; set; }
    [JsonPropertyName("timeLine")]
    public string Timeline { get; set; }
    [JsonPropertyName("viewMode")]
    public string ViewMode { get; set; }
}

public class Filter
{
    [JsonPropertyName("value")]
    public string Value { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
