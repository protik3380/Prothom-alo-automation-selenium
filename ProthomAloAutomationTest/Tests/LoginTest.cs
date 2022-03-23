using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProthomAloAutomationTest.Aggregates;
using ProthomAloAutomationTest.Pages;

namespace ProthomAloAutomationTest.Tests
{
    public class LoginTest
    {
        private static readonly IWebDriver Driver = new ChromeDriver();
        private readonly HomePage _homePage = new HomePage(Driver);

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl(ConstantClass.homePageUrl);
            Driver.Manage().Window.Maximize();
            Thread.Sleep(ConstantClass.timeCount);
        }
        [Test, Order(1)]
        public void LoginByUserEmail()
        {
            try
            {
                var loginPage = _homePage.ClickOnLogin();
                loginPage.Login(ConstantClass.UserEmail, ConstantClass.Password);
                Assert.That(_homePage.VerifyLogin(),Is.True);
            }
            catch (Exception e)
            {
                Driver.Quit();
                Console.WriteLine(e);
            }

        }

        //[TearDown]
        //public void CloseBrowser()
        //{
        //    Driver.Quit();
        //}

    }
}