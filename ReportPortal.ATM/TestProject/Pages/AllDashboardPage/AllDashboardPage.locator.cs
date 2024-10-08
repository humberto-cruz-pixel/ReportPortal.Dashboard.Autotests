using OpenQA.Selenium;

namespace TestProject.Pages.AllDashboardPage;

public partial class AllDashboardsPage
{
    private By _addNewDashboardLocator = By.XPath("//span[text()='Add New Dashboard']");
    private By _editDashboardLocator = By.CssSelector(".icon__icon--coE7b.icon__icon-pencil--hZNP6");

    private IWebElement AddNewDashboardButton => _webDriver.FindElement(_addNewDashboardLocator);
    private IWebElement DashboardInfoElement(string name) =>
        _webDriver.FindElement(By.XPath($"//div[@class='gridRow__grid-row--X9wIq']//*[text()='{name}']"));
    private IWebElement EditDashboardButton => _webDriver.FindElement(_editDashboardLocator);
}
