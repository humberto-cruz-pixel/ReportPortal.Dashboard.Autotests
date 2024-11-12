using ApiClientLibrary.Interfaces.Configurations;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Response;
using RestClientLibrary.Response;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace ApiClientLibrary.ApiClients;
public class HttpRestClient : IRestClientService
{
    private readonly HttpClient _httpClient;
    private HttpRequestMessage _httpRequest;
    private readonly string baseURL;
    private readonly IApiClientConfiguration _apiClientConfiguration;
    public HttpRestClient(IApiClientConfiguration apiClientConfiguration)
    {
        _apiClientConfiguration = apiClientConfiguration;
        _httpClient = new HttpClient();
        baseURL = apiClientConfiguration.BaseURL + "/v1/" + apiClientConfiguration.ProjectName;
    }

    public IRestClientService AddRequestParameters(Dictionary<string, string> parameters)
    {
        var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
        foreach (var parameter in parameters)
        {
            query[parameter.Key] = parameter.Value;
        }
        _httpRequest.RequestUri = new System.Uri(_httpClient.BaseAddress + _httpRequest.RequestUri.ToString() + "?" + query.ToString());
        return this;
    }

    public IRestClientService AddRequestBody<T>(T body) where T : class
    {
        var content = new StringContent(JsonSerializer.Serialize(body)
            , Encoding.UTF8, MediaTypeNames.Application.Json);

        _httpRequest.Content = content;
        return this;
    }

    public IRestClientService AddRequestHeaders(Dictionary<string, string> headers)
    {
        foreach (var header in headers)
        {
            _httpRequest.Headers.Add(header.Key, header.Value);
        }
        return this;
    }

    public IRestClientService CreateDeleteRequest(string resource)
    {
        _httpRequest = new HttpRequestMessage(HttpMethod.Delete, baseURL + resource);
        return this;
    }

    public IRestClientService CreateGetRequest(string resource)
    {
        _httpRequest = new HttpRequestMessage(HttpMethod.Get, baseURL + resource);
        return this;
    }

    public IRestClientService CreatePostRequest(string resource)
    {
        _httpRequest = new HttpRequestMessage(HttpMethod.Post, baseURL + resource);
        return this;
    }

    public IRestClientService CreatePutRequest(string resource)
    {
        _httpRequest = new HttpRequestMessage(HttpMethod.Put, baseURL + resource);
        return this;
    }

    public IRestClientResponse<T> ExecuteRequest<T>()
    {
        ArgumentNullException.ThrowIfNull(_httpRequest);

        _httpRequest.Headers.
            Add("Authorization", "Bearer " + _apiClientConfiguration.Token);

        var response = _httpClient.Send(_httpRequest);

        return new HttpClientResponse<T>(response);
    }
}