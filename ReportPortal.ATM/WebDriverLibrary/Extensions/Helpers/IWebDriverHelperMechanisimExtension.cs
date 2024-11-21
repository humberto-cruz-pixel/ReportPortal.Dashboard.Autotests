using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace WebDriverLibrary.Extensions.Helpers;

public static class IWebDriverHelperMechanisimExtension
{
    public static void JsClickOneElement(this IWebDriver webDriver, IWebElement webElement)
    {
        NullCheckAllParameters(webDriver, webElement);

        var jsExecutor = (IJavaScriptExecutor)webDriver;

        jsExecutor.ExecuteScript("arguments[0].click();", webElement);
    }

    public static void DragAndDrop(this IWebDriver webDriver, IWebElement webElement)
    {
        NullCheckAllParameters(webDriver, webElement);

        var actions = new Actions(webDriver);

        actions.DragAndDropToOffset(webElement, 400,0).Perform();
    }

    public static void ScrollToElement(this IWebDriver webDriver, IWebElement webElement)
    {
        NullCheckAllParameters(webDriver, webElement);

        var jsExecutor = (IJavaScriptExecutor)webDriver;

        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
    }

    public static bool IsElementScrolledIntoView(this IWebDriver webDriver, IWebElement webElement)
    {
        NullCheckAllParameters(webDriver, webElement);

        var jsExecutor = (IJavaScriptExecutor)webDriver;

        return (bool)jsExecutor.ExecuteScript(
            "var rect = arguments[0].getBoundingClientRect();" +
            "return (" +
            "rect.top >= 0 && " +
            "rect.left >= 0 && " +
            "rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) && " +
            "rect.right <= (window.innerWidth || document.documentElement.clientWidth)" +
            ");",
            webElement);
    }


    private static void NullCheckAllParameters(IWebDriver webDriver, IWebElement webElement)
    {
        ArgumentNullException.ThrowIfNull(webDriver);
        ArgumentNullException.ThrowIfNull(webElement);
    }
}