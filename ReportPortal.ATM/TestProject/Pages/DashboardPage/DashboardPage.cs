using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.DashboardPage;

public partial class DashboardPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;
    private IList<string> _widgetNames;
    private IList<string> _widgetTypes;

    public DashboardPage(IWebDriverService webDriverService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();

        _widgetNames = new List<string>();
        _widgetTypes = new List<string>();
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

    public void IsWidgetNameInDashboard(string name)
    {
        var names = GetWidgetNames();
        Assert.That(names.Contains(name));
    }

    public void IsWidgetTypeInDashboard(string type)
    {
        var types= GetWidgetTypes();
        Assert.That(types.Contains(type));
    }
}
