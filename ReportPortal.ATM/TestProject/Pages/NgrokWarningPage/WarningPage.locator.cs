using OpenQA.Selenium;

namespace TestProject.Pages.NgrokWarningPage;

public partial class WarningPage
{
    private By _visitSiteButtonLocator = By.XPath("//button[text()='Visit Site']");

    public IWebElement VisitSiteButton => _webDriver.FindElement(_visitSiteButtonLocator);
}