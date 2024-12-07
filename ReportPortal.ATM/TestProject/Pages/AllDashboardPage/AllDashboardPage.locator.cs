using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Pages.AllDashboardPage;

public partial class AllDashboardsPage
{
    private By _addNewDashboardLocator = By.XPath("//span[text()='Add New Dashboard']//ancestor::button");
    private By _editDashboardLocator = By.CssSelector(".icon__icon--coE7b.icon__icon-pencil--hZNP6");
    private By _dashboardNamesLocator = By.XPath("//div[@class='gridRow__grid-row--X9wIq']//a");
    private By _dashboardDescriptionsLocator = By.XPath("//div[@class='gridRow__grid-row--X9wIq']" +
        "//div[@class='gridCell__grid-cell--EIqeC gridCell__align-left--DFXWN dashboardTable__description--tHp7Q']");

    private IWebElement AddNewDashboardButton => _webDriver.FindElement(_addNewDashboardLocator);

    private IList<IWebElement> DashboardNames => _webDriver.FindElements(_dashboardNamesLocator).ToList();

    private IList<IWebElement> DashboardDescriptions => _webDriver.FindElements(_dashboardDescriptionsLocator).ToList();

    private IWebElement EditDashboardButton => _webDriver.FindElement(_editDashboardLocator);
}
