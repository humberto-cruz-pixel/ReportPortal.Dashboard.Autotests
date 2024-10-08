using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.AddNewDashboardPage;

public partial class AddNewDashboardPage
{

    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;

    public AddNewDashboardPage(IWebDriverService webDriverService)
    {

        ArgumentNullException.ThrowIfNull(webDriverService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
    }

    public void AddNewDashboard(string name, string description)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        NameInput.Clear();
        NameInput.SendKeys(name);

        DescriptionInput.Clear();
        DescriptionInput.SendKeys(description);

        ClickOnAdd();
    }
}
