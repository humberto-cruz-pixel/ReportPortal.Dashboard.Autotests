using RestClientLibrary.Interfaces.Response;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace RestClientLibrary.Response;

public class HttpClientResponse<T> : IRestClientResponse<T>
{
    private readonly HttpResponseMessage _response;

    public HttpClientResponse(HttpResponseMessage response)
    {
        _response = response;
    }

    public string Content => _response.Content.ReadAsStringAsync().Result;

    HttpStatusCode IRestClientResponse<T>.StatusCode => _response.StatusCode;

    public T GetData()
    {
        T result = _response.Content.ReadFromJsonAsync<T>().GetAwaiter().GetResult();
        return result;
    }
}