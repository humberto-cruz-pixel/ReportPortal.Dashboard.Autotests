using ApiClientLibrary.Interfaces.Configurations;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Response;
using RestClientLibrary.Response;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace RestClientLibrary.Clients;
public class HttpRestClient(IApiClientConfiguration apiClientConfiguration) : IRestClientService
{
    private readonly HttpClient _httpClient = new();
    private HttpRequestMessage _httpRequest = new();
    private readonly string _baseUrl = apiClientConfiguration.BaseURL + apiClientConfiguration.ProjectName;
    private readonly string _apiToken = Environment.GetEnvironmentVariable("API_TOKEN")!;

    public IRestClientService AddRequestParameters(Dictionary<string, string> parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
        foreach (var parameter in parameters)
        {
            query[parameter.Key] = parameter.Value;
        }
        _httpRequest.RequestUri = new Uri(_httpClient.BaseAddress + _httpRequest.RequestUri!.ToString() + "?" + query.ToString());
        return this;
    }

    public IRestClientService AddRequestBody<T>(T body) where T : class
    {
        ArgumentNullException.ThrowIfNull(body);

        var content = new StringContent(JsonSerializer.Serialize(body)
            , Encoding.UTF8, MediaTypeNames.Application.Json);

        _httpRequest.Content = content;
        return this;
    }

    public IRestClientService AddRequestHeaders(Dictionary<string, string> headers)
    {
        ArgumentNullException.ThrowIfNull(headers);

        foreach (var header in headers)
        {
            _httpRequest.Headers.Add(header.Key, header.Value);
        }
        return this;
    }

    public IRestClientService CreateDeleteRequest(string resource)
    {
        ArgumentNullException.ThrowIfNull(resource);

        _httpRequest = new HttpRequestMessage(HttpMethod.Delete, _baseUrl + resource);
        return this;
    }

    public IRestClientService CreateGetRequest(string resource)
    {
        ArgumentNullException.ThrowIfNull(resource);

        _httpRequest = new HttpRequestMessage(HttpMethod.Get, _baseUrl + resource);
        return this;
    }

    public IRestClientService CreatePostRequest(string resource)
    {
        ArgumentNullException.ThrowIfNull(resource);

        _httpRequest = new HttpRequestMessage(HttpMethod.Post, _baseUrl + resource);
        return this;
    }

    public IRestClientService CreatePutRequest(string resource)
    {
        ArgumentNullException.ThrowIfNull(resource);

        _httpRequest = new HttpRequestMessage(HttpMethod.Put, _baseUrl + resource);
        return this;
    }

    public IRestClientResponse<T> ExecuteRequest<T>()
    {
        ArgumentNullException.ThrowIfNull(_httpRequest);

        _httpRequest.Headers.
            Add("Authorization", "Bearer " + _apiToken);

        var response = _httpClient.Send(_httpRequest);

        return new HttpClientResponse<T>(response);
    }
}