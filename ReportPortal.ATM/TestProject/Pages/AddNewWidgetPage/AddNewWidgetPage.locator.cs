using OpenQA.Selenium;

namespace TestProject.Pages.AddNewWidgetPage;

public partial class AddNewWidgetPage
{
    private By _nextStepButtonLocator = By.XPath("//span[text()='Next step']");
    private By _defaultFilterSelector = By.ClassName("inputRadio__toggler--ygpdQ");
    private By _widgetNameInputLocator = By.XPath("//input[@placeholder='Enter widget name']");
    private By _addWidgetButtonLocator = By.XPath("//button[text()='Add']");
    private By _widgetTypeLocator = By.CssSelector(".widgetHeader__type--yZiVg");
    private By _widgetNamesLocator = By.CssSelector(".widgetHeader__widget-name-block--AOAHS");

    public IWebElement WidgetTypeInput(string type) => _webDriver.
        FindElement(By.XPath($"//div[text()='{type}']/parent::span/preceding-sibling::span"));
    public IWebElement NextStepButton => _webDriver.FindElement(_nextStepButtonLocator);
    public IWebElement DefaultFilter => _webDriver.FindElement(_defaultFilterSelector);
    public IWebElement WidgetNameInput => _webDriver.FindElement(_widgetNameInputLocator);
    public IWebElement AddWidgetButton => _webDriver.FindElement(_addWidgetButtonLocator);
    public IWebElement WidgetType=>_webDriver.FindElement(_widgetTypeLocator);
}
