using ApiClientLibrary.Configurations;
using ApiClientLibrary.Interfaces.Configurations;
using ConfigurationLibrary.Configuration;
using ConfigurationLibrary.Interfaces.Configuration;
using LoggerLibrary.Factories;
using LoggerLibrary.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;
using ReporterLibrary.Interfaces.Reporters;
using ReporterLibrary.Reporters;
using RestClientLibrary.Factories;
using RestClientLibrary.Interfaces.Factories;
using System;
using WebDriverLibrary.Configurations;
using WebDriverLibrary.Interfaces.Configurations;
using WebDriverLibrary.Interfaces.WebDrivers;
using WebDriverLibrary.WebDrivers;

namespace FrameworkFacade.FrameworkStartup;

public class FrameworkService
{
    private readonly IServiceProvider _serviceProvider;

    public FrameworkService(string filePath, string fileName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

        _serviceProvider = new ServiceCollection()
            .AddSingleton<IConfigurationService>(new ConfigurationService(filePath, fileName))
            .AddScoped<ILoggerServiceFactory, LoggerServiceFactory>()
            .AddSingleton<IWebDriverConfiguration, WebDriverConfiguration>()
            .AddScoped<IWebDriverService, SeleniumWebDriverService>()
            .AddSingleton<IReporterService, ExtentReporterService>()
            .AddSingleton<IApiClientConfiguration, ApiClientConfiguration>()
            .AddTransient<IRestClientServiceFactory, RestClientServiceFactory>()
            .BuildServiceProvider();
    }

    public IServiceProvider GetServiceProvider()
    {
        return _serviceProvider;
    }
}