using System.Text.Json.Serialization;

namespace APITests.Models.Response;

public class Response
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("content")]
    public List<ContentItem>? Content { get; set; }

    [JsonPropertyName("page")]
    public PageInfo? Page { get; set; }

    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

public class PageInfo
{
    public int? Number { get; set; }
    public int? Size { get; set; }
    public int? TotalElements { get; set; }
    public int? TotalPages { get; set; }
}

public class ContentItem
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("widgets")]
    public List<Widget>? Widgets { get; set; }

    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

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

public class WidgetSize
{
    public int? Width { get; set; }
    public int? Height { get; set; }
}

public class WidgetPosition
{
    public int? PositionX { get; set; }
    public int? PositionY { get; set; }
}