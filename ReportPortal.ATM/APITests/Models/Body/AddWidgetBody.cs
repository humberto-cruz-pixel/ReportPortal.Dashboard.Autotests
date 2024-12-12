using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APITests.Models.Body;

public class AddWidgetBody
{
    [JsonPropertyName("widgetType")]
    public string? WidgetType { get; set; }
    [JsonPropertyName("contentParameters")]
    public ContentParameters? ContentParameters { get; set; }
    [JsonPropertyName("filters")]
    public List<Filter>? Filters { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("filterIds")]
    public List<string>? FilterIds { get; set; }
}