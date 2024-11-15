using ApiClientLibrary.ApiClients;
using ApiClientLibrary.Interfaces.Configurations;
using RestClientLibrary.Enums;
using RestClientLibrary.Interfaces.Factories;
using System;

namespace RestClientLibrary.Factories;

public class RestClientServiceFactory : IRestClientServiceFactory
{
    public Interfaces.Clients.IRestClientService Create(RestClientServiceType restClientServiceType, IApiClientConfiguration apiClientConfiguration)
    {
        switch (restClientServiceType)
        {
            case RestClientServiceType.RestSharp:
                return new RestSahrpClient(apiClientConfiguration);

            case RestClientServiceType.HttpClient:
                return new HttpRestClient(apiClientConfiguration);

            default:
                throw new NotImplementedException();
        }
    }
}