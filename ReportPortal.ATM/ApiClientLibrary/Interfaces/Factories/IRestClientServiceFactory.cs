using ApiClientLibrary.Interfaces.Configurations;
using RestClientLibrary.Enums;
using RestClientLibrary.Interfaces.Clients;

namespace RestClientLibrary.Interfaces.Factories
{
    public interface IRestClientServiceFactory
    {
        IRestClientService Create(RestClientServiceType restClientServiceType, IApiClientConfiguration apiClientConfiguration);
    }
}