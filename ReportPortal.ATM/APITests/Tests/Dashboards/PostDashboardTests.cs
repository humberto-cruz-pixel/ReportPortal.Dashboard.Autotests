﻿using System.Net;
using System;
using System.Linq;

namespace APITests.Tests.Dashboards;

public class PostDashboardTests : BaseTest
{
    [Test]
    public void Should_CreateDashboard()
    {
        var name = Guid.NewGuid().ToString();
        var description = Guid.NewGuid().ToString();

        loggerService.LogInformation($"Creating dashboard: {name}");

        var response = dashboardService.CreateDashboard(name, description);
        var id = response.GetData().Id;

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, 
                Is.EqualTo(HttpStatusCode.Created), $"Expected {HttpStatusCode.Created} status code, but found: {response.StatusCode}");

            Assert.That(id, Is.Not.Null, "Id should not be empty");

        });

        loggerService.LogInformation($"Dashboard: {name} was sucessfully created");

        var responseGetD = dashboardService.GetAllDashboards().GetData();

        loggerService.LogInformation($"Searching for dashboard: {name} on all created");

        var Ids = responseGetD.Content!.Select(x => x.Id).ToList();
        var names = responseGetD.Content!.Select(x => x.Name).ToList();
        var descriptions = responseGetD.Content!.Select(x => x.Description).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(Ids,Does.Contain(id));
            Assert.That(names, Does.Contain(name));
            Assert.That(descriptions, Does.Contain(description));
        });

        loggerService.LogInformation($"Dashboard: {name} was found successfully");

        dashboardService.DeleteDashboardAsync(id.ToString());
    }

    [Test]
    public void Should_CreateDashboardFailWhenMissingName()
    {
        var description = Guid.NewGuid().ToString();

        var response = dashboardService.CreateDashboard(" ", description);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, 
                Is.EqualTo(HttpStatusCode.BadRequest), $"Expected failed status code, but found: {response.StatusCode}");

            Assert.That(response.GetData().Message, 
                Is.EqualTo("Incorrect Request. [Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] "));
        });
    }
}
