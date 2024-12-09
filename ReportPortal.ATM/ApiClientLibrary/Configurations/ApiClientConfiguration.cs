using ApiClientLibrary.Interfaces.Configurations;
using ConfigurationLibrary.Interfaces.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace ApiClientLibrary.Configurations;

public class ApiClientConfiguration : IApiClientConfiguration
{
    public string BaseURL { get; set; }
    public string ProjectName { get; set; }

    public ApiClientConfiguration(IConfigurationService configurationService)
    {
        ArgumentNullException.ThrowIfNull(configurationService);

        var section = configurationService.GetConfigurationSection<IConfigurationSection>("ApiClientConfiguration");

        section.Bind(this);
    }
}