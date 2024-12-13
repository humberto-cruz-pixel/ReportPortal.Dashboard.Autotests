using System;
using System.Linq;
using System.Net;

namespace APITests.Tests.Widgets;

public class DeleteWidgetTests : BaseTest
{
    [Test]
    public void Should_DeleteWidgetFromDashboard()
    {
        var name = Guid.NewGuid().ToString();

        var dashboardId = dashboardService.CreateDashboard(name, "")
            .GetData().Id;
        var widgetName = Guid.NewGuid().ToString();

        loggerService.LogInformation($"Dashboard: {name} was successfully created");
        loggerService.LogInformation($"Adding widget: {widgetName} to dashboard: {name}");

        var widgetId = widgetService.AddWidget(widgetName)
            .GetData().Id;

        _ = dashboardService.AddWidgetAsync(dashboardId, widgetId, "Name");

        loggerService.LogInformation($"Widget: {widgetName} was added to dashboard: {name}");
        loggerService.LogInformation($"Trying to delete widget: {widgetName} from dashboard: {name}...");

        var deleteWidgetResult = dashboardService.DeleteWidgetAsync(dashboardId, widgetId);

        var Widgets = dashboardService.GetDashboardById(dashboardId.ToString())
                                      .GetData().Widgets!
                                      .Select(x => x.WidgetName)
                                      .ToList();

        Assert.Multiple(() =>
        {
            Assert.That(deleteWidgetResult.StatusCode, Is.EqualTo(HttpStatusCode.OK)
                , $"Expected succes status code, but found: {deleteWidgetResult.StatusCode}");

            Assert.That(Widgets, Does.Not.Contain(widgetName));

        });

        loggerService.LogInformation($"Widget: {widgetName} was deleted from dashboard: {name}");

        dashboardService.DeleteDashboardAsync(dashboardId.ToString());
    }
}
