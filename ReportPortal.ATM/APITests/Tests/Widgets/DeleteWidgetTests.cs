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

        var widgetId = widgetService.AddWidget(widgetName)
            .GetData().Id;

        _ = dashboardService.AddWidgetAsync(dashboardId, widgetId, "Name");

        var deleteWidgetResult = dashboardService.DeleteWidgetAsync(dashboardId, widgetId);

        var Widgets = dashboardService.GetDashboardById(dashboardId.ToString())
            .GetData().Widgets.Select(x => x.WidgetName).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(deleteWidgetResult.StatusCode.Equals(HttpStatusCode.OK)
                , $"Expected succes status code, but found: {deleteWidgetResult.StatusCode}");

            Assert.That(Widgets.Contains(widgetName), Is.False);

        });

        dashboardService.DeleteDashboardAsync(dashboardId.ToString());
    }
}
