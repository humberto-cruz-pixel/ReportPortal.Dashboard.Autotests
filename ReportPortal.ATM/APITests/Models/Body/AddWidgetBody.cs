namespace APITests.Models.Body;

public class AddWidgetBody
{
    public string WidgetType { get; set; }
    public ContentParameters ContentParameters { get; set; }
    public List<Filter> Filters { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> FilterIds { get; set; }
}

public class ContentParameters
{
    public List<string> ContentFields { get; set; }
    public string ItemsCount { get; set; }
    public WidgetOptions WidgetOptions { get; set; }
}

public class WidgetOptions
{
    public bool Zoom { get; set; }
    public string Timeline { get; set; }
    public string ViewMode { get; set; }
}

public class Filter
{
    public string Value { get; set; }
    public string Name { get; set; }
}
