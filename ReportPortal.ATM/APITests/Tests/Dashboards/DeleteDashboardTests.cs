using System.Net;
using System;
using System.Linq;

namespace APITests.Tests.Dashboards;

public class DeleteDashboardTests : BaseTest
{

    [Test]
    public void Should_DeleteDashboard()
    {
        var name = Guid.NewGuid().ToString();

        var id = dashboardService.CreateDashboard(name, "")
            .GetData().Id;

        var response = dashboardService.DeleteDashboardAsync(id.ToString());

        var daashboardsIds = dashboardService.GetAllDashboards()
            .GetData().Content.Select(x => x.Id).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode.Equals(HttpStatusCode.OK), $"Expected succes status code, but found: {response.StatusCode}");
            Assert.That(daashboardsIds.Contains(id), Is.False);
        });
    }

    [Test]
    public void Should_DeleteDashboardFailWhenIdNotFound()
    {
        var response = dashboardService.DeleteDashboardAsync("-1");

        var daashboardsIds = dashboardService.GetAllDashboards()
            .GetData().Content.Select(x => x.Id).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is
                .EqualTo(HttpStatusCode.NotFound), $"Expected failed status code, but found: {response.StatusCode}");
            Assert.That(response.GetData().Message
                .Equals($"Dashboard with ID '-1' not found on project 'superadmin_personal'. Did you use correct Dashboard ID?"));
        });
    }
}
