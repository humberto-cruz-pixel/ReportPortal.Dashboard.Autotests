﻿using ConfigurationLibrary.Configuration;
using ConfigurationLibrary.Interfaces.Configuration;
using LoggerLibrary.Interfaces.Loggers;
using LoggerLibrary.Loggers;
using Microsoft.Extensions.DependencyInjection;

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
            .BuildServiceProvider();
    }

    public IServiceProvider GetServiceProvider()
    {
        return _serviceProvider;
    }
}