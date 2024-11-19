using System.Text.Json.Serialization;

namespace APITests.Models.Body;

public class AddWidgetToDashboardBody
{
    [JsonPropertyName("addWidget")]
    public AddWidget addWidget { get; set; }
}