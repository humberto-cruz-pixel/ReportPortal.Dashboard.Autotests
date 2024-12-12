using APITests.Models.Body;
using APITests.Models.Response;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Response;
using System;

namespace APITests.Services;

public class WidgetService(IRestClientService apiClientService)
{
    private readonly IRestClientService _apiClientService = apiClientService;

    public IRestClientResponse<Response> AddWidget(string? widgetName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(widgetName);

        AddWidgetBody widgetRequest = new()
        {
            WidgetType = "statisticTrend",
            ContentParameters = new ContentParameters
            {
                ContentFields =
                [
                    "statistics$executions$total",
                    "statistics$executions$passed",
                ],
                ItemsCount = "50",
                WidgetOptions = new WidgetOptions
                {
                    Zoom = false,
                    Timeline = "launch",
                    ViewMode = "area-spline"
                }
            },
            Filters =
            [
                new Filter { Value = "1", Name = "DEMO_FILTER" }
            ],
            Name = widgetName,
            Description = "",
            FilterIds = ["1"]
        };

        var response = _apiClientService.CreatePostRequest($"/widget")
            .AddRequestBody(widgetRequest)
            .ExecuteRequest<Response>();

        return response;
    }
}