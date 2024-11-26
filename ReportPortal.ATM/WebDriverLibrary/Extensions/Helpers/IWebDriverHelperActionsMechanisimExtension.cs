using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;

namespace WebDriverLibrary.Extensions.Helpers;

public static class IWebDriverHelperActionsMechanisimExtension
{
    public static void DragAndDrop(this IWebDriver webDriver, IWebElement webElement, int offsetX, int offsetY)
    {
        NullCheckAllParameters(webDriver, webElement, offsetX, offsetY);

        var actions = new Actions(webDriver);

        actions.DragAndDropToOffset(webElement, 400, 0).Perform();
    }

    private static void NullCheckAllParameters(IWebDriver webDriver, IWebElement webElement, int offsetX, int offsetY)
    {
        ArgumentNullException.ThrowIfNull(webDriver);
        ArgumentNullException.ThrowIfNull(webElement);
        ArgumentNullException.ThrowIfNull(offsetX);
        ArgumentNullException.ThrowIfNull(offsetY);
    }
}