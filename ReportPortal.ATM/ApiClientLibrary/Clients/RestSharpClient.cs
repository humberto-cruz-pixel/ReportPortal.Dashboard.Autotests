﻿using ApiClientLibrary.Interfaces.Configurations;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Response;
using RestClientLibrary.Response;
using RestSharp;
using System;
using System.Collections.Generic;

namespace RestClientLibrary.Clients;

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
        _restClient = new RestClient(_restClientOptions!);
        var _apiToken = Environment.GetEnvironmentVariable("API_TOKEN")!;
        _restClient.AddDefaultHeader("Authorization", "Bearer " + _apiToken);
        _restRequest = new RestRequest();
        _restClientOptions = new RestClientOptions();
    }

    public IRestClientService CreateGetRequest(string resource)
    {
        ArgumentNullException.ThrowIfNull(resource);

        _restRequest = new RestRequest(resource, Method.Get);
        return this;
    }

    public IRestClientService CreatePostRequest(string resource)
    {
        ArgumentNullException.ThrowIfNull(resource);

        _restRequest = new RestRequest(resource, Method.Post);
        return this;
    }

    public IRestClientService CreatePutRequest(string resource)
    {
        ArgumentNullException.ThrowIfNull(resource);

        _restRequest = new RestRequest(resource, Method.Put);
        return this;
    }

    public IRestClientService CreateDeleteRequest(string resource)
    {
        ArgumentNullException.ThrowIfNull(resource);

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
        ArgumentNullException.ThrowIfNull(body);

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
        var baseURL = _apiClientConfiguration.BaseURL + _apiClientConfiguration.ProjectName;
        _restClientOptions = new RestClientOptions(baseURL);
    }
}