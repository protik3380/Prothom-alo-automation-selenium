using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProthomAloAutomationTest.Aggregates;
using SeleniumExtras.PageObjects;


namespace ProthomAloAutomationTest.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
           
        
        private IWebElement HomeTitleImage => _driver.FindElement(By.XPath("/html/body/div[1]/header/div/div/div/div/div[1]/div[2]/a/h2/img"));

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
            //_driver = new ChromeDriver();
        }

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl(ConstantClass.homePageUrl);
            _driver.Manage().Window.Maximize();
            Thread.Sleep(ConstantClass.timeCount);
        }

        public void VerifySite() => Assert.That(HomeTitleImage.Displayed,Is.True);
    }
}