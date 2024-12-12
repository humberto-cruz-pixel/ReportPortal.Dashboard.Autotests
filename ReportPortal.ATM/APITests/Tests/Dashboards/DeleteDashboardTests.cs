using System;
using System.Linq;
using System.Net;

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

        var dashboardsIds = dashboardService.GetAllDashboards()
            .GetData().Content!
            .Select(x => x.Id)
            .ToList();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected success status code, but found: {response.StatusCode}");

            Assert.That(dashboardsIds, Does.Not.Contain(id),
                $"Expected 'dashboardsIds' to not contain the id: {id}");
        });
    }

    [Test]
    public void Should_DeleteDashboardFailWhenIdNotFound()
    {
        var response = dashboardService.DeleteDashboardAsync("-1");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode,
                Is.EqualTo(HttpStatusCode.NotFound), $"Expected failed status code, but found: {response.StatusCode}");

            Assert.That(response.GetData().Message!,
                Is.EqualTo($"Dashboard with ID '-1' not found on project 'superadmin_personal'. Did you use correct Dashboard ID?"));
        });
    }
}
