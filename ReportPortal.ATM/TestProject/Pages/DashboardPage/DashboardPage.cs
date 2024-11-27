using Dynamitey.DynamicObjects;
using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.DashboardPage;

public partial class DashboardPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;
    private readonly ILoggerService _loggerService;

    public DashboardPage(IWebDriverService webDriverService, ILoggerService loggerService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);
        ArgumentNullException.ThrowIfNull(loggerService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
        _loggerService = loggerService;

        _loggerService.LogInformation("Dashboard Page instantiation complete");
    }

    public void DeleteDashboard()
    {
        ClickOnDeleteButton();
        ClickOnConfirmDeleteButton();
    }

    public void OpenAddWidget()
    {
        ClickOnAddWidgetButton();
    }

    public IList<string> GetWidgetNames()
    {
        WaitForWidgetNames();
        return WidgetNames.Select(x => x.Text).ToList();
    }

    public IList<string> GetWidgetTypes()
    {
        WaitForWidgetTypes();
        return WidgetTypes.Select(x => x.Text).ToList();
    }

    public void MoveWidgetPosition(int offsetX, int offsetY)
    {
        MoveWidgetOffset(GetWidgetNames().FirstOrDefault()!, offsetX, offsetY);
    }

    public IList<int> GetWidgetPosition(string widgetName)
    {
        return GetWidgetTransaleValues(GetWidgetContainerByName(widgetName));
    }

    public IList<int> GetWidgetPosition()
    {
        return GetWidgetTransaleValues(GetWidgetContainerByName(GetWidgetNames().FirstOrDefault()!));
    }
}
