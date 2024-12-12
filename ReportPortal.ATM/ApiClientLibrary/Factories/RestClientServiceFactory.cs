using ApiClientLibrary.Interfaces.Configurations;
using RestClientLibrary.Clients;
using RestClientLibrary.Enums;
using RestClientLibrary.Interfaces.Factories;
using System;

namespace RestClientLibrary.Factories;

public class RestClientServiceFactory : IRestClientServiceFactory
{
    public Interfaces.Clients.IRestClientService Create(RestClientServiceType restClientServiceType, IApiClientConfiguration apiClientConfiguration)
    {
        return restClientServiceType switch
        {
            RestClientServiceType.RestSharp => new RestSahrpClient(apiClientConfiguration),
            RestClientServiceType.HttpClient => new HttpRestClient(apiClientConfiguration),
            _ => throw new NotImplementedException(),
        };
    }
}