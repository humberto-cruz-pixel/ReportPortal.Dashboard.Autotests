using System.Net;
using System;

namespace APITests.Tests.Dashboards;

public class PutDashboardTests : BaseTest
{
    [Test]
    public void Should_EditDashboard()
    {
        var description = Guid.NewGuid().ToString();
        var name = Guid.NewGuid().ToString();

        var id = dashboardService.CreateDashboard(name, description)
            .GetData().Id.ToString();

        var response = dashboardService.EditDashboardAsync(id, name, description);

        loggerService.LogInformation($"Dashboard: {name} was successfully created");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, 
                Is.EqualTo(HttpStatusCode.OK), $"Expected succesful status code, but found: {response.StatusCode}");

            Assert.That(response.GetData().Message!, 
                Is.EqualTo($"Dashboard with ID = '{id}' successfully updated"));
        });

        loggerService.LogInformation($"Dashboard was successfully edited");

        dashboardService.DeleteDashboardAsync(id);
    }

    [Test]
    public void Should_EditDashboardFailWhenIdNotFound()
    {
        var response = dashboardService.EditDashboardAsync("-1", "name", "description");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, 
                Is.EqualTo(HttpStatusCode.NotFound), $"Expected failed status code, but found: {response.StatusCode}");

            Assert.That(response.GetData().Message!,
                Is.EqualTo($"Dashboard with ID '-1' not found on project 'superadmin_personal'. Did you use correct Dashboard ID?"));
        });
    }
}