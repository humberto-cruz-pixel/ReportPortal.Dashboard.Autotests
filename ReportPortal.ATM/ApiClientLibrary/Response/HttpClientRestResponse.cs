using RestClientLibrary.Interfaces.Response;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace RestClientLibrary.Response;

public class HttpClientResponse<T>(HttpResponseMessage response) : IRestClientResponse<T>
{
    private readonly HttpResponseMessage _response = response;

    public string Content => _response.Content.ReadAsStringAsync().Result;

    HttpStatusCode IRestClientResponse<T>.StatusCode => _response.StatusCode;

    public T GetData()
    {
        T result = _response.Content.ReadFromJsonAsync<T>()
            .GetAwaiter()
            .GetResult()!;
        return result;
    }
}