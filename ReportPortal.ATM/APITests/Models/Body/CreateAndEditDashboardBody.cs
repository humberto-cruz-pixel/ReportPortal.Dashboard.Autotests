using System.Text.Json.Serialization;

namespace APITests.Models.Body;

public class CreateAndEditDashboardBody
{
    [JsonPropertyName("name")]
    public string ?Name { get; set; }
    [JsonPropertyName("description")]
    public string ?Description { get; set; }
}
