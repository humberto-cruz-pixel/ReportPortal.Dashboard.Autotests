using ApiClientLibrary.Interfaces.Configurations;
using APITests.Services;
using FrameworkFacade.FrameworkStartup;
using Microsoft.Extensions.DependencyInjection;
using RestClientLibrary.Enums;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Factories;
using System.IO;

namespace APITests.Tests;

public class BaseTest
{
    protected IServiceScope frameworkScope;
    protected IRestClientServiceFactory restClientFactory;
    protected IRestClientService restClientService;
    protected IRestClientService httpRestClientService;
    protected Dashboard dashboardService;
    protected WidgetService widgetService;

    [OneTimeSetUp]
    public void Setup()
    {
        frameworkScope = new FrameworkService(Directory.GetCurrentDirectory(), "appsettings.json")
        .GetServiceProvider().CreateScope();

        var apiClientConfiguration = frameworkScope.ServiceProvider.GetRequiredService<IApiClientConfiguration>();

        restClientFactory = frameworkScope.ServiceProvider.GetRequiredService<IRestClientServiceFactory>();

        restClientService = restClientFactory.Create(RestClientServiceType.RestSharp, apiClientConfiguration);

        httpRestClientService = restClientFactory.Create(RestClientServiceType.HttpClient, apiClientConfiguration);

        dashboardService = new Dashboard(restClientService);
        widgetService = new WidgetService(restClientService);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        frameworkScope.Dispose();
    }
}