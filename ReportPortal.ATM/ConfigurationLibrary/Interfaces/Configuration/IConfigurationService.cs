using Microsoft.Extensions.Configuration;

namespace ConfigurationLibrary.Interfaces.Configuration
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
        T GetConfigurationalue<T>(string key);
        T GetConfigurationSection<T>(string sectionName);
    }
}