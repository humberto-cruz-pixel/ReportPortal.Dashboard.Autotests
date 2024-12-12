using APITests.Services;
using System.Net;
using System;

namespace APITests.Tests.Dashboards;

public class GetDashboardTests : BaseTest
{

    [Test]
    public void Should_GetAllDashboards_usingHttpClient()
    {
        var response = new Dashboard(httpRestClientService).GetAllDashboards();
        var data = response.GetData();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.OK));
            Assert.That(data.Page!.Number, Is.GreaterThan(0), "Should be at least 1 page");
            Assert.That(data.Page.Size, Is.GreaterThan(0), "Size can't be 0");
            Assert.That(data.Page.TotalElements,Is.GreaterThanOrEqualTo(0), "Total elements can't be less than 0");
            Assert.That(data.Page.TotalPages,Is.GreaterThanOrEqualTo(0), "Total pages can't be less than 0");
        });
    }

    [Test]
    public void Should_GetAllDashboards()
    {
        var response = dashboardService.GetAllDashboards();
        var data = response.GetData();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.OK));
            Assert.That(data.Page!.Number, Is.GreaterThan(0), "Should be at least 1 page");
            Assert.That(data.Page.Size, Is.GreaterThan(0), "Size can't be 0");
            Assert.That(data.Page.TotalElements, Is.GreaterThanOrEqualTo(0), "Total elements can't be less than 0");
            Assert.That(data.Page.TotalPages, Is.GreaterThanOrEqualTo(0), "Total pages can't be less than 0");
        });
    }

    [Test]
    public void Should_GetDashboardById()
    {
        var name = Guid.NewGuid().ToString();

        var id = dashboardService.CreateDashboard(name, "test")
            .GetData().Id.ToString();

        var response = dashboardService.GetDashboardById(id);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, 
                Is.EqualTo(HttpStatusCode.OK), $"Expected succesful status code, but found: {response.StatusCode}");

            Assert.That(response.GetData().Name!, Is.EqualTo(name));
        });

        dashboardService.DeleteDashboardAsync(id);
    }

    [Test]
    public void Should_GetDashboardByIdFailWhenIdNotFound()
    {
        var response = dashboardService.GetDashboardById("-1");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, 
                Is.EqualTo(HttpStatusCode.NotFound), $"Expected failed status code, but found: {response.StatusCode}");

            Assert.That(response.GetData().Message, 
                Is.EqualTo("Dashboard with ID '-1' not found on project 'superadmin_personal'. Did you use correct Dashboard ID?"));

        });
    }
}
