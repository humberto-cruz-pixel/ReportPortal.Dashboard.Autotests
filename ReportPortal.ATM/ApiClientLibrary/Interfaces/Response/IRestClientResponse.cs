using System.Net;

namespace RestClientLibrary.Interfaces.Response;

public interface IRestClientResponse<out T>
{
    HttpStatusCode StatusCode { get; }
    string Content { get; }
    T GetData();
}