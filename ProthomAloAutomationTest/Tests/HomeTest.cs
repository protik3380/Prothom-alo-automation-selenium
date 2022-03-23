using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProthomAloAutomationTest.Aggregates;
using ProthomAloAutomationTest.Pages;

namespace ProthomAloAutomationTest.Tests
{
    public class HomeTest
    {
        private static readonly IWebDriver Driver = new ChromeDriver();
        private readonly HomePage _homePage = new HomePage(Driver);

        [Test, Order(0)]
        public void LaunchWebSite()
        {
            try
            {
                _homePage.GoToHomePage();
                _homePage.VerifySite();
            }
            catch (Exception e)
            {
                Driver.Quit();
                Console.WriteLine(e);
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}