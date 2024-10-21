using OpenQA.Selenium;

namespace TestProject.Pages.AddNewDashboardPage;

public partial class AddNewDashboardPage
{
    private By _nameInputLocator = By.XPath("//input[@placeholder='Enter dashboard name']");
    private By _descriptionInputLocator = By.XPath("//textarea[@placeholder='Enter dashboard description']");
    private By _addButtonLocator = By.XPath("//Button[text()='Add' or text()='Update']");

    private IWebElement NameInput => _webDriver.FindElement(_nameInputLocator);
    private IWebElement DescriptionInput => _webDriver.FindElement(_descriptionInputLocator);
    private IWebElement AddButton => _webDriver.FindElement(_addButtonLocator);
}