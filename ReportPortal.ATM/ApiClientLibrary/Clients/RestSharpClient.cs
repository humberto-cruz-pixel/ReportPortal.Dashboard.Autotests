using ApiClientLibrary.Interfaces.Configurations;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Response;
using RestClientLibrary.Response;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ApiClientLibrary.ApiClients;

public class RestSahrpClient : IRestClientService
{
    private readonly IApiClientConfiguration _apiClientConfiguration;
    private readonly IRestClient _restClient;
    private RestRequest _restRequest;
    private RestClientOptions _restClientOptions;

    public RestSahrpClient(IApiClientConfiguration apiClientConfiguration)
    {
        _apiClientConfiguration = apiClientConfiguration;
        ConfigureApiClient();
        _restClient = new RestClient(_restClientOptions);
        _restClient.AddDefaultHeader("Authorization", "Bearer " + _apiClientConfiguration.Token);
    }

    public IRestClientService CreateGetRequest(string resource)
    {
        _restRequest = new RestRequest(resource, Method.Get);
        return this;
    }

    public IRestClientService CreatePostRequest(string resource)
    {
        _restRequest = new RestRequest(resource, Method.Post);
        return this;
    }

    public IRestClientService CreatePutRequest(string resource)
    {
        _restRequest = new RestRequest(resource, Method.Put);
        return this;
    }

    public IRestClientService CreateDeleteRequest(string resource)
    {
        _restRequest = new RestRequest(resource, Method.Delete);
        return this;
    }

    public IRestClientService AddRequestHeaders(Dictionary<string, string> headers)
    {
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentNullException.ThrowIfNull(_restRequest);

        _restRequest.AddHeaders(headers);
        return this;
    }

    public IRestClientService AddRequestParameters(Dictionary<string, string> parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        ArgumentNullException.ThrowIfNull(_restRequest);

        foreach (var parameter in parameters)
        {
            _restRequest.AddParameter(parameter.Key, parameter.Value);
        }

        return this;
    }

    public IRestClientService AddRequestBody<T>(T body) where T : class
    {
        _restRequest.AddJsonBody(body);
        return this;
    }

    public IRestClientResponse<T> ExecuteRequest<T>()
    {
        ArgumentNullException.ThrowIfNull(_restRequest);

        var response = _restClient.Execute<T>(_restRequest);

        return new RestSharpClientResponse<T>(response);
    }

    private void ConfigureApiClient()
    {
        var baseURL = _apiClientConfiguration.BaseURL + "/v1/" + _apiClientConfiguration.ProjectName;
        _restClientOptions = new RestClientOptions(baseURL);
    }
}