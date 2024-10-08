﻿using ConfigurationLibrary.Configuration;
using ConfigurationLibrary.Interfaces.Configuration;
using LoggerLibrary.Interfaces.Loggers;
using LoggerLibrary.Loggers;
using Microsoft.Extensions.DependencyInjection;
using ReporterLibrary.Interfaces.Reporters;
using ReporterLibrary.Reporters;
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
            .AddScoped<ILoggerService, SerilogLoggerService>()
            .AddSingleton<IWebDriverConfiguration, WebDriverConfiguration>()
            .AddScoped<IWebDriverService, SeleniumWebDriverService>()
            .AddSingleton<IReporterService, ExtentReporterService>()
            .BuildServiceProvider();
    }

    public IServiceProvider GetServiceProvider()
    {
        return _serviceProvider;
    }
}