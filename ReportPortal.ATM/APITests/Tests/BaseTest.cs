using ApiClientLibrary.Interfaces.Configurations;
using APITests.Services;
using FrameworkFacade.FrameworkStartup;
using LoggerLibrary.Interfaces.Factories;
using LoggerLibrary.Interfaces.Loggers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Interfaces;
using RestClientLibrary.Enums;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Factories;
using System;
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
    protected ILoggerService loggerService;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        frameworkScope = new FrameworkService(Directory.GetCurrentDirectory(), "appsettings.json")
        .GetServiceProvider().CreateScope();

        DotNetEnv.Env.Load(Directory.GetCurrentDirectory() + "\\Enviroment.env");

        var apiClientConfiguration = frameworkScope.ServiceProvider.GetRequiredService<IApiClientConfiguration>();

        restClientFactory = frameworkScope.ServiceProvider.GetRequiredService<IRestClientServiceFactory>();

        restClientService = restClientFactory.Create(RestClientServiceType.RestSharp, apiClientConfiguration);

        httpRestClientService = restClientFactory.Create(RestClientServiceType.HttpClient, apiClientConfiguration);

        dashboardService = new Dashboard(restClientService);
        widgetService = new WidgetService(restClientService);

        var fullFilePath = $"Logs\\{DateTime.Today.ToString("yyyy-MM-dd")}.txt";

        loggerService = frameworkScope.ServiceProvider.GetRequiredService<ILoggerServiceFactory>()
            .CreateLoggerService(fullFilePath);
    }

    [SetUp]
    public void Setup()
    {
        loggerService.LogInformation($"Initializing Test:{TestContext.CurrentContext.Test.Name}");
    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;

        switch (status)
        {
            case TestStatus.Passed:
                loggerService.LogInformation(TestContext.CurrentContext.Result.Outcome.ToString()!);
                break;

            case TestStatus.Failed:
                loggerService.LogError(TestContext.CurrentContext.Result.Outcome.ToString()!);
                break;

            case TestStatus.Warning:
                loggerService.LogWarning(TestContext.CurrentContext.Result.Outcome.ToString()!);
                break;

            case TestStatus.Skipped:
                loggerService.LogWarning(TestContext.CurrentContext.Result.Outcome.ToString()!);
                break;

            default:
                throw new IndexOutOfRangeException(status.ToString(), null);
        }
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        loggerService.CloseAndFlush();
        frameworkScope.Dispose();
    }
}