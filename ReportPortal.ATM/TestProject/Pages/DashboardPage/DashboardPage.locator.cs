using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestProject.Pages.DashboardPage;

public partial class DashboardPage
{

    private By _deleteButtonLoocator = By.XPath("//span[text()='Delete']");
    private By _confirmDeleteButtonLoocator = By.XPath("//button[text()='Delete']");
    private By _addWidgetButtonLocator = By.XPath("//span[text()='Add new widget']/ancestor::button");
    private By _widgetNamesLocator = By.CssSelector(".widgetHeader__widget-name-block--AOAHS");
    private By _widgetTypesLocator = By.CssSelector(".widgetHeader__type--yZiVg");
    private By _widgetGridContainerLocator = By
        .XPath("./ancestor::div[@class='react-grid-item widgetsGrid__widget-view--PZkC5 react-draggable cssTransforms react-resizable']");
    private By _widgetHeaderLocator = By.XPath("./ancestor::div[@class='widgetHeader__info-block--Lp75m']");
    
    public IWebElement DeleteButton => _webDriver.FindElement(_deleteButtonLoocator);
    public IWebElement ConfirmDeleteButton => _webDriver.FindElement(_confirmDeleteButtonLoocator);
    public IWebElement AddWidgetButton => _webDriver.FindElement(_addWidgetButtonLocator);
    public IList<IWebElement> WidgetNames => _webDriver.FindElements(_widgetNamesLocator);
    public IList<IWebElement> WidgetTypes => _webDriver.FindElements(_widgetTypesLocator);
}