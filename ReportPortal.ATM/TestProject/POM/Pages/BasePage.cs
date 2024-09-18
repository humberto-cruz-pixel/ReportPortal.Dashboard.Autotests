
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject.POM.Pages;

public class BasePage
{
    protected IWebDriver Driver { get; set; }

    public BasePage(IWebDriver webDriver)
    {
        Driver = webDriver;
        PageFactory.InitElements(Driver, this);
    }
}
