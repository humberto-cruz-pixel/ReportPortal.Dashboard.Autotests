using RestClientLibrary.Interfaces.Response;
using System.Collections.Generic;

namespace RestClientLibrary.Interfaces.Clients;

public interface IRestClientService
{
    public IRestClientService AddRequestBody<T>(T body) where T : class;
    public IRestClientService AddRequestHeaders(Dictionary<string, string> headers);
    public IRestClientService AddRequestParameters(Dictionary<string, string> parameters);
    public IRestClientService CreateDeleteRequest(string resource);
    public IRestClientService CreateGetRequest(string resource);
    public IRestClientService CreatePostRequest(string resource);
    public IRestClientService CreatePutRequest(string resource);
    public IRestClientResponse<T> ExecuteRequest<T>();
}