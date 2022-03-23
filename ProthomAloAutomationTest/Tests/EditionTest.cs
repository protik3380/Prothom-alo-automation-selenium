using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProthomAloAutomationTest.Aggregates;
using ProthomAloAutomationTest.Pages;

namespace ProthomAloAutomationTest.Tests
{
    public class EditionTest
    {
        private static readonly IWebDriver Driver = new ChromeDriver();
        private readonly HomePage _homePage = new HomePage(Driver);
        private readonly HelperClass _helperClass = new HelperClass(Driver);

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl(ConstantClass.homePageUrl);
            Driver.Manage().Window.Maximize();
            Thread.Sleep(5000);

            //if (Driver.SwitchTo().Alert() != null)
            //{
            //    IAlert alert = Driver.SwitchTo().Alert();
            //    alert.Dismiss(); // alert.accept();
            //}
            //var a =Driver.WindowHandles;
            //var b = Driver.CurrentWindowHandle;

            //find the frame by class/title/type/source
            //IWebElement detailFrame = Driver.FindElement(By.XPath("//iframe[@class='google_ads_iframe_85406138/home_Int_660x440_0']"));
            //Driver.SwitchTo().Frame(detailFrame);

            //alternatively, find the frame first, then use GetAttribute() to get frame name
            //IWebElement detailFrame = driver.FindElement(By.XPath("//iframe[@class='class1']"));
            //driver.SwitchTo().Frame(detailFrame.GetAttribute("name"));

            ////you are now in iframe "Details", then find the elements you want in the frame now
            //IWebElement foo = driver.FindElement(By.Id("foo"));
            //foo.Click();

            //switch back to main frame
            //Driver.SwitchTo().DefaultContent();
        }
        
        [Test, Order(2)]
        public void EditorTest()
        {
            try
            {
                Thread.Sleep(ConstantClass.timeCount);
                _homePage.ScrollToFooter();
                Thread.Sleep(ConstantClass.timeCount);
                _homePage.CheckEditionEnglish();
                Thread.Sleep(ConstantClass.timeCount);
                _homePage.ScrollToFooter();
                Thread.Sleep(ConstantClass.timeCount);
                _homePage.CheckEditionBangla();
                Thread.Sleep(ConstantClass.timeCount);
                //_homePage.ScrollToFooter();
                //Thread.Sleep(ConstantClass.timeCount);
                //_homePage.CheckEditionAmerica();
                //Thread.Sleep(ConstantClass.timeCount);

            }
            catch (Exception e)
            {
                Driver.Quit();
                Console.WriteLine(e);
            }

        }
    }
}