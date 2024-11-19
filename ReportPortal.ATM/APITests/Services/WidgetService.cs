using APITests.Models.Body;
using APITests.Models.Response;
using RestClientLibrary.Interfaces.Clients;
using RestClientLibrary.Interfaces.Response;
using System;
using System.Collections.Generic;

namespace APITests.Services;

public class WidgetService
{
    private readonly IRestClientService _apiClientService;

    public WidgetService(IRestClientService apiClientService)
    {
        _apiClientService = apiClientService;
    }

    public IRestClientResponse<Response> AddWidget(string widgetName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(widgetName);

        AddWidgetBody widgetRequest = new AddWidgetBody
        {
            WidgetType = "statisticTrend",
            ContentParameters = new ContentParameters
            {
                ContentFields = new List<string>
                {
                    "statistics$executions$total",
                    "statistics$executions$passed",
                },
                ItemsCount = "50",
                WidgetOptions = new WidgetOptions
                {
                    Zoom = false,
                    Timeline = "launch",
                    ViewMode = "area-spline"
                }
            },
            Filters = new List<Filter>
            {
                new Filter { Value = "1", Name = "DEMO_FILTER" }
            },
            Name = widgetName,
            Description = "",
            FilterIds = new List<string> { "1" }
        };

        var response = _apiClientService.CreatePostRequest($"/widget")
            .AddRequestBody(widgetRequest)
            .ExecuteRequest<Response>();

        return response;
    }
}