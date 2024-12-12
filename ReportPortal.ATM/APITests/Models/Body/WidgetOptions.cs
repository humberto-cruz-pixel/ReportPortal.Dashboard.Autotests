using System.Text.Json.Serialization;

namespace APITests.Models.Body;

public class WidgetOptions
{
    [JsonPropertyName("zoom")]
    public bool Zoom { get; set; }
    [JsonPropertyName("timeLine")]
    public string ?Timeline { get; set; }
    [JsonPropertyName("viewMode")]
    public string ?ViewMode { get; set; }
}