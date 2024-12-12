using RestClientLibrary.Interfaces.Response;
using RestSharp;
using System.Net;

namespace RestClientLibrary.Response;

public class RestSharpClientResponse<T>(RestResponse<T> response) : IRestClientResponse<T>
{
    private readonly RestResponse<T> _response = response;

    public HttpStatusCode StatusCode => _response.StatusCode;
    public string Content => _response.Content!;
    public T GetData()
    {
        return _response.Data!; 
    }
}