﻿using OpenQA.Selenium;

namespace TestProject.Pages.NavBar;

public partial class NavBarPage
{
    private By _dashboardsPageLocator = By.XPath("//span[text()='Dashboards']/parent::span");

    private IWebElement DashboardsPageButton => _webDriver.FindElement(_dashboardsPageLocator);
}
