using ApiClientLibrary.Interfaces.Configurations;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Response;
using RestClientLibrary.Response;

namespace ApiClientLibrary.ApiClients;
public class HttpRestClient : IRestClientService
{
    private readonly HttpClient _httpClient;
    private HttpRequestMessage _httpRequest;
    private string baseURL;

    public HttpRestClient(IApiClientConfiguration apiClientConfiguration)
    {
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
        _httpRequest.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8, "application/json");
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
            Add("Authorization", "Bearer" + "NET_I9NhoXx5Rj-aN6dBpDCPrh6xIMZ8LNIidtUIM0i9H1_oYxA7uDRbk3HY7B-SvHAj");

        var response = _httpClient.Send(_httpRequest);


        return new HttpClientResponse<T>(response);
    }
}