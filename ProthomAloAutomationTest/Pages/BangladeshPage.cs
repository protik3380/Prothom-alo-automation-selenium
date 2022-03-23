using System;
using OpenQA.Selenium;

namespace ProthomAloAutomationTest.Pages
{
    public class BangladeshPage
    {
        //  /html/body/div/header/div/div/div/div/div[2]/nav/ul/li[1]/div/a

        private readonly IWebDriver _driver;


        private IWebElement BangladeshMenu => _driver.FindElement(By.XPath("/html/body/div/header/div/div/div/div/div[2]/nav/ul/li[1]/div/a"));
        private IWebElement PoliticsSubMenu => _driver.FindElement(By.XPath("/html/body/div/div[8]/div/div[1]/ul/li[1]/a"));

        public BangladeshPage(IWebDriver driver)
        {
            this._driver = driver;
            //_driver = new ChromeDriver();
        }

        public void GoToBangladeshMenu()
        {
            BangladeshMenu.Click();
        }

        public void GoToPoliticsPage()
        {
            PoliticsSubMenu.Click();
        }

        //public void PageZoomIn()
        //{

        //}

    }
}