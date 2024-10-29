using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.AddNewWidgetPage;

public partial class AddNewWidgetPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;
    private int _nWidget;

    public AddNewWidgetPage(IWebDriverService webDriverService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
        _nWidget = 0;
    }

    public void AddNewWidget(string type, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(type);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        _nWidget += 1;
        SelectWidget(type);
        ClickOneNextStepButton();
        ClickOnDefaultFilter();
        ClickOneNextStepButton();
        WidgetNameClearAndSendKeys(name);
        ClickOnAddWidget();
    }
}