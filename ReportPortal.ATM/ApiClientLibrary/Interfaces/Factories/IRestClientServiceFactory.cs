using ConfigurationLibrary.Interfaces.Configuration;
using RestClientLibrary.Enums;
using RestClientLibrary.Interfaces.Clients;

namespace RestClientLibrary.Interfaces.Factories
{
    public interface IRestClientServiceFactory
    {
        IRestClientService Create(RestClientServiceType restClientServiceType, IConfigurationService configurationService);
    }
}