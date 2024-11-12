using APITests.Models.Response;

namespace APITests.Models.Body;

public class AddWidgetToDashboardBody
{
    public AddWidget addWidget { get; set; }
}

public class AddWidget
{
    public int? WidgetId { get; set; }
    public string WidgetName { get; set; }
    public WidgetOptions WidgetOptions { get; set; }
    public WidgetPosition WidgetPosition { get; set; }
    public WidgetSize WidgetSize { get; set; }
    public string WidgetType { get; set; }
}