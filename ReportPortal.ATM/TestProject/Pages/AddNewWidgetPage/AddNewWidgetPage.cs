using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.AddNewWidgetPage;

public partial class AddNewWidgetPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;

    public AddNewWidgetPage(IWebDriverService webDriverService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
    }

    public void AddNewWidget(string type, string name, int widgetCount)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(type);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        ClickWidgetLabel(type);
        ClickOneNextStepButton();
        ClickOnDefaultFilter();
        ClickOneNextStepButton();
        WidgetNameClearAndSendKeys(name);
        ClickOnAddWidget();
        WaitForWidgetsCountToBe(widgetCount);
    }
}