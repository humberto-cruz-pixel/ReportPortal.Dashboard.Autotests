using System;
using System.Linq;
using System.Net;

namespace APITests.Tests.Widgets;

public class AddWidgetTests : BaseTest
{
    [Test]
    public void Should_AddWidgetToDashboard()
    {
        var name = Guid.NewGuid().ToString();

        var dashboardId = dashboardService.CreateDashboard(name, "")
            .GetData().Id;
        var widgetName = Guid.NewGuid().ToString();

        var widgetId = widgetService.AddWidget(widgetName)
            .GetData().Id;

        var addWidgetResult = dashboardService.AddWidgetAsync((int)dashboardId!, widgetId, "Name");

        Assert.That(addWidgetResult.StatusCode,
            Is.EqualTo(HttpStatusCode.OK), $"Expected succesful status code, but found: {addWidgetResult.StatusCode}");

        var Widgets = dashboardService.GetDashboardById(dashboardId.ToString()!)
                                      .GetData().Widgets!
                                      .Select(x => x.WidgetName)
                                      .ToList()!;

        Assert.That(Widgets, Does.Contain(widgetName));

        dashboardService.DeleteDashboardAsync(dashboardId.ToString()!);
    }
}
