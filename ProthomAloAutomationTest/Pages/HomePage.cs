using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using ProthomAloAutomationTest.Aggregates;
using SeleniumExtras.PageObjects;


namespace ProthomAloAutomationTest.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
           
            
        private IWebElement HomeTitleImage => _driver.FindElement(By.XPath("/html/body/div[1]/header/div/div/div/div/div[1]/div[2]/a/h2/img"));
        private IWebElement LoginButton => _driver.FindElement(By.XPath("/html/body/div[1]/header/div/div/div/div/div[1]/div[3]/div[1]/a/div/button"));
       // private IWebElement ProfilePanel => _driver.FindElement(By.XPath("/html/body/div[1]/header/div/div/div/div/div[1]/div[3]/div[1]/div[2]"));
        private IWebElement EditorPanel => _driver.FindElement(By.XPath("/html/body/div[1]/header/div/div/div/div/div[1]/div[3]/div[2]/div[1]"));
        private IWebElement BanglaEditionLabelAnchor => _driver.FindElement(By.XPath("/html/body/footer/div/div[1]/div[2]/ul/li[2]/a"));
        private IWebElement EngEditionLabelAnchor => _driver.FindElement(By.XPath("/html/body/footer/div/div[1]/div[2]/ul/li[3]/a"));
        private IWebElement AmericaEditionLabelAnchor => _driver.FindElement(By.XPath("/html/body/footer/div/div[1]/div[2]/ul/li[4]/a"));

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

        public void GoToHomePageEnglish()
        {
            _driver.Navigate().GoToUrl(ConstantClass.EngHomePageUrl);
            _driver.Manage().Window.Maximize();
            Thread.Sleep(ConstantClass.timeCount);
        }
        public LoginPage ClickOnLogin()
        {
            LoginButton.Click();
            return new LoginPage(_driver);
        }
        public void VerifySite() => Assert.That(HomeTitleImage.Displayed,Is.True);
        public bool VerifyLogin()
        {
           var count= _driver.FindElements(By.XPath("/html/body/div[1]/header/div/div/div/div/div[1]/div[3]/div[1]/div[2]")).Count;
           if (count>0)
           {
               return true;
           }
           return false;
        }

        public void HoverToEditorDiv()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(EditorPanel).Build().Perform();
        }
        public void ScrollToFooter()
        {
            var helper = new HelperClass(_driver);
            helper.ScrollToBottom();
        }

        public void CheckEditionBangla()
        {
            BanglaEditionLabelAnchor.Click();
            String strUrl = _driver.Url;
            Assert.AreEqual("https://www.prothomalo.com/", strUrl);
        }

        public void CheckEditionEnglish()
        {
            EngEditionLabelAnchor.Click();
            String strUrl = _driver.Url;
            Assert.AreEqual("https://en.prothomalo.com/", strUrl);
        }

        public void CheckEditionAmerica()
        {
            AmericaEditionLabelAnchor.Click();
            String strUrl = _driver.Url;
            Assert.AreEqual("https://northamerica.prothomalo.com/", strUrl);
        }
    }
}