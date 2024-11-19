using RestClientLibrary.Interfaces.Response;
using RestSharp;
using System.Net;

namespace RestClientLibrary.Response;

public class RestSharpClientResponse<T> : IRestClientResponse<T>
{
    private readonly RestResponse<T> _response;

    public RestSharpClientResponse(RestResponse<T> response)
    {
        _response = response;
    }

    public HttpStatusCode StatusCode => _response.StatusCode;
    public string Content => _response.Content;
    public T GetData()
    {
        return _response.Data; 
    }
}