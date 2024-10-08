using OpenQA.Selenium;

namespace TestProject.Pages.DashboardPage;

public partial class DashboardPage
{

    private By _deleteButtonLoocator = By.XPath("//span[text()='Delete']");
    private By _confirmDeleteButtonLoocator = By.XPath("//button[text()='Delete']");

    private IWebElement DeleteButton => _webDriver.FindElement(_deleteButtonLoocator);
    private IWebElement ConfirmDeleteButton => _webDriver.FindElement(_confirmDeleteButtonLoocator);
}
 