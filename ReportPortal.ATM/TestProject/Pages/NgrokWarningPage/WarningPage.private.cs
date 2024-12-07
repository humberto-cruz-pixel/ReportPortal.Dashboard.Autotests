using System;
using WebDriverLibrary.Extensions.WebDrivers;

namespace TestProject.Pages.NgrokWarningPage;

public partial class WarningPage
{

    private void ClickOnVisistsite()
    {
        if(IsVisitSiteButtonDisplayed())
        {
            try
            {
                _webDriver.WaitUntilElementIsClickable(_visitSiteButtonLocator,
                    _webDriverService.GetWebDriverConfiguration().LongTimeout,
                    _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

                VisitSiteButton.Click();
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, "An error occurred while clicking Visit site button.", _visitSiteButtonLocator);
                throw;
            }
        }
    }

    private bool IsVisitSiteButtonDisplayed() 
    { 
        try 
        { 
            return VisitSiteButton.Displayed; 
        } 
        catch 
        { 
            return false; 
        } 
    }

}
