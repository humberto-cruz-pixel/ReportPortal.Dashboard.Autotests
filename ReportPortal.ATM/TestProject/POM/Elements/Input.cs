using OpenQA.Selenium;
using System;

namespace TestProject.POM.Elements
{
    public class Input
    {
        private readonly By _locator;
        public IWebElement WebElement;

        public Input(IWebDriver webDriver, By locator)
        {
            _locator = locator;
            WebElement = webDriver.FindElement(_locator);
            
        }

        public void ClearAndSendKeys(string value)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
            WebElement.Clear();
            WebElement.SendKeys(value);
        }

    }
}
