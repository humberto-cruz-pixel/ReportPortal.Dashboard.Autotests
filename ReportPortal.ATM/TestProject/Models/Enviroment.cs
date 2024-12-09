using ConfigurationLibrary.Interfaces.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace TestProject.Models;

public class Enviroment
{
    public string URL { get; set; }

    public Enviroment(IConfigurationService configurationService)
    {
        ArgumentNullException.ThrowIfNull(configurationService);

        var section = configurationService.GetConfigurationSection<IConfigurationSection>("Enviroment");

        section.Bind(this);
    }
}