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

    public DashboardPage(IWebDriverService webDriverService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
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
}
