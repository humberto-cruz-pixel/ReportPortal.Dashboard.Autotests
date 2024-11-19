using APITests.Models.Body;
using APITests.Models.Response;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Response;
using System;

namespace APITests.Services;

public class Dashboard
{
    private readonly IRestClientService _apiClientService;

    public Dashboard(IRestClientService apiClientService)
    {
        _apiClientService = apiClientService;
    }

    public IRestClientResponse<Response> GetAllDashboards()
    {
        var response = _apiClientService.CreateGetRequest("/dashboard")
            .ExecuteRequest<Response>();
        return response;
    }

    public IRestClientResponse<ContentItem> GetDashboardById(string id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);

        var response = _apiClientService.CreateGetRequest($"/dashboard/{id}")
            .ExecuteRequest<ContentItem>();

        return response;
    }

    public IRestClientResponse<Response> CreateDashboard(string name, string description)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(description);

        var dashboard = new CreateAndEditDashboardBody
        {
            Name = name,
            Description = description
        };

        var response = _apiClientService.CreatePostRequest("/dashboard")
            .AddRequestBody(dashboard)
            .ExecuteRequest<Response>();

        return response;
    }

    public IRestClientResponse<Response> EditDashboardAsync(string id, string name, string description)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(description);
        ArgumentNullException.ThrowIfNull(id);

        var dashboard = new CreateAndEditDashboardBody
        {
            Name = name,
            Description = description
        };

        var response = _apiClientService.CreatePutRequest($"/dashboard/{id}")
            .AddRequestBody(dashboard)
            .ExecuteRequest<Response>();

        return response;
    }

    public IRestClientResponse<Response> DeleteDashboardAsync(string id)
    {
        ArgumentNullException.ThrowIfNull(id);

        var response = _apiClientService.CreateDeleteRequest($"/dashboard/{id}")
            .ExecuteRequest<Response>();

        return response;
    }

    public IRestClientResponse<Response> AddWidgetAsync(int? dashboardId, int? widgetId, string widgetName)
    {
        ArgumentNullException.ThrowIfNull(dashboardId);
        ArgumentNullException.ThrowIfNull(widgetId);
        ArgumentNullException.ThrowIfNull(widgetName);

        AddWidgetToDashboardBody widgetRequest = new AddWidgetToDashboardBody
        {
            addWidget = new AddWidget
            {
                WidgetId = widgetId,
                WidgetName = widgetName,
                WidgetOptions = new WidgetOptions(),
                WidgetPosition = new WidgetPosition
                {
                    PositionX = 0,
                    PositionY = 0
                },
                WidgetSize = new WidgetSize
                {
                    Height = 6,
                    Width = 7
                },
                WidgetType = "statisticTrend"
            }
        };

        var response = _apiClientService.CreatePutRequest($"/dashboard/{dashboardId}/add")
            .AddRequestBody(widgetRequest)
            .ExecuteRequest<Response>();

        return response;
    }

    public IRestClientResponse<Response> DeleteWidgetAsync(int? dashboardId, int? widgetId)
    {
        ArgumentNullException.ThrowIfNull(dashboardId);
        ArgumentNullException.ThrowIfNull(widgetId);

        var response = _apiClientService.CreateDeleteRequest($"/dashboard/{dashboardId}/{widgetId}")
            .ExecuteRequest<Response>();

        return response;
    }
}
