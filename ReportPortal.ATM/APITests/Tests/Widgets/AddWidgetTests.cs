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

        loggerService.LogInformation($"Dashboard: {name} was successfully created");
        loggerService.LogInformation($"Adding widget: {widgetName} to dashboard: {name}...");

        Assert.That(addWidgetResult.StatusCode,
            Is.EqualTo(HttpStatusCode.OK), $"Expected succesful status code, but found: {addWidgetResult.StatusCode}");

        var Widgets = dashboardService.GetDashboardById(dashboardId.ToString()!)
                                      .GetData().Widgets!
                                      .Select(x => x.WidgetName)
                                      .ToList()!;

        Assert.That(Widgets, Does.Contain(widgetName));

        loggerService.LogInformation($"Widget: {widgetName} was added to dashboard: {name}");

        dashboardService.DeleteDashboardAsync(dashboardId.ToString()!);
    }
}
