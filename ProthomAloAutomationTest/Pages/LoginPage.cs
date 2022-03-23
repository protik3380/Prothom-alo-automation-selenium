using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using ProthomAloAutomationTest.Aggregates;

namespace ProthomAloAutomationTest.Pages
{
    public class LoginPage
    {
        //String homePageUrl = Locators.homePageUrl;

        private readonly IWebDriver _driver;
        private IWebElement EmailTextBox => _driver.FindElement(By.XPath("/html/body/div[1]/div[7]/div/form/div/div[1]/div/div[3]/input"));
        private IWebElement PasswordTextBox => _driver.FindElement(By.XPath("/html/body/div[1]/div[7]/div/form/div/div[1]/div/div[4]/div/input"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("/html/body/div[1]/div[7]/div/form/div/div[1]/div/button"));

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            
        }

        public void Login(string email, string password)
        {
            EmailTextBox.SendKeys(email);
            PasswordTextBox.SendKeys(password);
            Thread.Sleep(ConstantClass.timeCount);
            LoginButton.Submit();
        }
    }
}