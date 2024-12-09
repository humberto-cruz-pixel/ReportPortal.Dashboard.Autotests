namespace ApiClientLibrary.Interfaces.Configurations;

public interface IApiClientConfiguration
{
    public string BaseURL { get; set; }
    public string ProjectName { get; set; }
}