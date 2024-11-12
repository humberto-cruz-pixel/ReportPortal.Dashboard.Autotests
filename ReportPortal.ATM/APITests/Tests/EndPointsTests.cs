using APITests.Services;
using ConfigurationLibrary.Interfaces.Configuration;
using FrameworkFacade.FrameworkStartup;
using Microsoft.Extensions.DependencyInjection;
using RestClientLibrary.Enums;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Factories;
using System.Net;

namespace APITests.Tests;

public class Tests
{
    private IServiceScope _frameworkScope;
    private IRestClientServiceFactory _restClientFactory;
    private IRestClientService _restClientService;
    private IRestClientService _httpRestClientService;
    private Dashboard _dashboardService;
    private WidgetService _widgetService;

    [SetUp]
    public void Setup()
    {
        _frameworkScope = new FrameworkService(Directory.GetCurrentDirectory(), "appsettings.json")
            .GetServiceProvider().CreateScope();

        var configurationService = _frameworkScope.ServiceProvider.GetRequiredService<IConfigurationService>();

        _restClientFactory = _frameworkScope.ServiceProvider.GetRequiredService<IRestClientServiceFactory>();

        _restClientService = _restClientFactory.Create(RestClientServiceType.RestSharp, configurationService);

        _httpRestClientService = _restClientFactory.Create(RestClientServiceType.HttpClient, configurationService);

        _dashboardService = new Dashboard(_restClientService);
        _widgetService = new WidgetService(_restClientService);
    }

    [Test]
    public void Should_GetAllDashboards_usingHttpClient()
    {
        var response = new Dashboard(_httpRestClientService).GetAllDashboards();
        var data = response.GetData();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.That(data.Page.Number > 0, "Should be at least 1 page");
            Assert.That(data.Page.Size > 0, "Size can't be 0");
            Assert.That(data.Page.TotalElements >= 0, "Total elements can't be less than 0");
            Assert.That(data.Page.TotalPages >= 0, "Total pages can't be less than 0");
        });
    }

    [Test]
    public void Should_GetAllDashboards()
    {
        var response = _dashboardService.GetAllDashboards();
        var data = response.GetData();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.That(data.Page.Number > 0, "Should be at least 1 page");
            Assert.That(data.Page.Size > 0, "Size can't be 0");
            Assert.That(data.Page.TotalElements >= 0, "Total elements can't be less than 0");
            Assert.That(data.Page.TotalPages >= 0, "Total pages can't be less than 0");
        });
    }

    [Test]
    public void Should_GetDashboardById()
    {
        var name = Guid.NewGuid().ToString();

        var id = _dashboardService.CreateDashboard(name, "test")
            .GetData().Id.ToString();

        var response = _dashboardService.GetDashboardById(id);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode.Equals(HttpStatusCode.OK), $"Expected succesful status code, but found: {response.StatusCode}");
            Assert.That(response.GetData().Name.Equals(name));

        });

        _dashboardService.DeleteDashboardAsync(id);
    }

    [Test]
    public void Should_GetDashboardByIdFailWhenIdNotFound()
    {
        var response = _dashboardService.GetDashboardById("-1");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), $"Expected failed status code, but found: {response.StatusCode}");
            Assert.That(response.GetData().Message.Equals("Dashboard with ID '-1' not found on project 'superadmin_personal'. Did you use correct Dashboard ID?"));

        });
    }

    [Test]
    public void Should_CreateDashboard()
    {
        var name = Guid.NewGuid().ToString();
        var description = Guid.NewGuid().ToString();

        var response = _dashboardService.CreateDashboard(name, description);
        var id = response.GetData().Id;

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode.Equals(HttpStatusCode.Created), $"Expected succesful status code, but found: {response.StatusCode}");
            Assert.That(id, Is.Not.Null, "Id should not be empty");

        });

        var responseGetD = _dashboardService.GetAllDashboards().GetData();

        var Ids = responseGetD.Content.Select(x => x.Id).ToList();
        var names = responseGetD.Content.Select(x => x.Name).ToList();
        var descriptions = responseGetD.Content.Select(x => x.Description).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(Ids.Contains(id));
            Assert.That(names.Contains(name));
            Assert.That(descriptions.Contains(description));
        });
        _dashboardService.DeleteDashboardAsync(id.ToString());
    }

    [Test]
    public void Should_CreateDashboardFailWhenMissingName()
    {
        var description = Guid.NewGuid().ToString();

        var response = _dashboardService.CreateDashboard(" ", description);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is
                .EqualTo(HttpStatusCode.BadRequest), $"Expected failed status code, but found: {response.StatusCode}");

            Assert.That(response.GetData().Message, Is.
                EqualTo("Incorrect Request. [Field 'name' should not contain only white spaces and shouldn't be empty. Field 'name' should have size from '3' to '128'.] "));

        });
    }


    [Test]
    public void Should_EditDashboard()
    {
        var description = Guid.NewGuid().ToString();
        var name = Guid.NewGuid().ToString();

        var id = _dashboardService.CreateDashboard(name, description)
            .GetData().Id.ToString();

        var response = _dashboardService.EditDashboardAsync(id, name, description);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode.Equals(HttpStatusCode.OK), $"Expected succesful status code, but found: {response.StatusCode}");
            Assert.That(response.GetData().Message.Equals($"Dashboard with ID = '{id}' successfully updated"));
        });

        _dashboardService.DeleteDashboardAsync(id);
    }

    [Test]
    public void Should_EditDashboardFailWhenIdNotFound()
    {
        var response = _dashboardService.EditDashboardAsync("-1", "name", "description");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is
                .EqualTo(HttpStatusCode.NotFound), $"Expected failed status code, but found: {response.StatusCode}");
            Assert.That(response.GetData().Message
                .Equals($"Dashboard with ID '-1' not found on project 'superadmin_personal'. Did you use correct Dashboard ID?"));
        });
    }

    [Test]
    public void Should_DeleteDashboard()
    {
        var name = Guid.NewGuid().ToString();

        var id = _dashboardService.CreateDashboard(name, "")
            .GetData().Id;

        var response = _dashboardService.DeleteDashboardAsync(id.ToString());

        var daashboardsIds = _dashboardService.GetAllDashboards()
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
        var response = _dashboardService.DeleteDashboardAsync("-1");

        var daashboardsIds = _dashboardService.GetAllDashboards()
            .GetData().Content.Select(x => x.Id).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is
                .EqualTo(HttpStatusCode.NotFound), $"Expected failed status code, but found: {response.StatusCode}");
            Assert.That(response.GetData().Message
                .Equals($"Dashboard with ID '-1' not found on project 'superadmin_personal'. Did you use correct Dashboard ID?"));
        });
    }

    [Test]
    public void Should_AddWidgetToDashboard()
    {
        var name = Guid.NewGuid().ToString();

        var dashboardId = _dashboardService.CreateDashboard(name, "")
            .GetData().Id;

        var widgetName = Guid.NewGuid().ToString();

        var widgetId = _widgetService.AddWidgetAsync( widgetName)
            .GetData().Id;

        var addWidgetResult = _dashboardService.AddWidgetAsync(dashboardId,widgetId, "Name");

        Assert.That(addWidgetResult.StatusCode
            .Equals(HttpStatusCode.OK), $"Expected succesful status code, but found: {addWidgetResult.StatusCode}");
        
        var Widgets = _dashboardService.GetDashboardById(dashboardId.ToString())
            .GetData().Widgets.Select(x => x.WidgetName).ToList();

        Assert.That(Widgets.Contains(widgetName));
        
        _dashboardService.DeleteDashboardAsync(dashboardId.ToString());

    }

    [Test]
    public void Should_DeleteWidgetFromDashboard()
    {
        var name = Guid.NewGuid().ToString();

        var dashboardId = _dashboardService.CreateDashboard(name, "")
            .GetData().Id;

        var widgetName = Guid.NewGuid().ToString();

        var widgetId = _widgetService.AddWidgetAsync(widgetName)
            .GetData().Id;

        _ = _dashboardService.AddWidgetAsync(dashboardId, widgetId, "Name");

        var deleteWidgetResult = _dashboardService.DeleteWidgetAsync(dashboardId, widgetId);

        var Widgets = _dashboardService.GetDashboardById(dashboardId.ToString())
            .GetData().Widgets.Select(x => x.WidgetName).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(deleteWidgetResult.StatusCode.Equals(HttpStatusCode.OK)
                , $"Expected succes status code, but found: {deleteWidgetResult.StatusCode}");

            Assert.That(Widgets.Contains(widgetName),Is.False);

        });

        _dashboardService.DeleteDashboardAsync(dashboardId.ToString());
    }

    public void Should_DeleteWidgetFromDashboard_HTTPClient()
    {
        var name = Guid.NewGuid().ToString();

        var dashboardId = _dashboardService.CreateDashboard(name, "")
            .GetData().Id;

        var widgetName = Guid.NewGuid().ToString();

        var widgetId = _widgetService.AddWidgetAsync(widgetName)
            .GetData().Id;

        _ = _dashboardService.AddWidgetAsync(dashboardId, widgetId, "Name");

        var deleteWidgetResult = _dashboardService.DeleteWidgetAsync(dashboardId, widgetId);

        var Widgets = _dashboardService.GetDashboardById(dashboardId.ToString())
            .GetData().Widgets.Select(x => x.WidgetName).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(deleteWidgetResult.StatusCode.Equals(HttpStatusCode.OK)
                , $"Expected succes status code, but found: {deleteWidgetResult.StatusCode}");

            Assert.That(Widgets.Contains(widgetName), Is.False);

        });

        _dashboardService.DeleteDashboardAsync(dashboardId.ToString());
    }

    [TearDown]
    public void TearDown()
    {
        _frameworkScope.Dispose();
    }
}