using ApiClientLibrary.ApiClients;
using ApiClientLibrary.Configurations;
using ConfigurationLibrary.Interfaces.Configuration;
using RestClientLibrary.Enums;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Factories;

namespace RestClientLibrary.Factories;

public class RestClientServiceFactory : IRestClientServiceFactory
{
    public Interfaces.Clients.IRestClientService Create(RestClientServiceType restClientServiceType, IConfigurationService configurationService)
    {
        var apiClientConfiguration = new ApiClientConfiguration(configurationService);
        switch (restClientServiceType)
        {
            case RestClientServiceType.RestSharp:
                return new RestSahrpClient(apiClientConfiguration);

            case RestClientServiceType.HttpClient:
                return new ApiClientLibrary.ApiClients.HttpRestClient(apiClientConfiguration);

            default:
                throw new NotImplementedException();
        }
    }
}