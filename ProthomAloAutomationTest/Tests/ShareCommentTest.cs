using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProthomAloAutomationTest.Aggregates;
using ProthomAloAutomationTest.Pages;

namespace ProthomAloAutomationTest.Tests
{
    public class ShareCommentTest
    {
        private static readonly IWebDriver Driver = new ChromeDriver();
        private readonly HomePage _homePage = new HomePage(Driver);
        private readonly HelperClass _helperClass = new HelperClass(Driver);
        private readonly BangladeshPage _bangladeshPage = new BangladeshPage(Driver);


        [SetUp]
        public void SetUp()
        {
            _homePage.GoToHomePageEnglish();
            _bangladeshPage.GoToBangladeshMenu();
            Thread.Sleep(ConstantClass.timeCount);
            _bangladeshPage.GoToPoliticsPage();
            Thread.Sleep(ConstantClass.timeCount);

        }
        [Test, Order(3)]
        public void PageTextZoomIn()
        {
            try
            {
                
                _helperClass.ZoomIn(10);
                Thread.Sleep(ConstantClass.timeCount);
                _helperClass.ZoomIn(10);
                Thread.Sleep(ConstantClass.timeCount);
                _helperClass.ZoomIn(10);
                Thread.Sleep(ConstantClass.timeCount);
            }
            catch (Exception e)
            {
                Driver.Quit();
                Console.WriteLine(e);
            }

        }

        [Test, Order(4)]
        public void PageTextZoomOut()
        {
            try
            {
                _helperClass.ZoomOut(10);
                Thread.Sleep(ConstantClass.timeCount);
                _helperClass.ZoomOut(10);
                Thread.Sleep(ConstantClass.timeCount);
                _helperClass.ZoomOut(10);
                Thread.Sleep(ConstantClass.timeCount);

            }
            catch (Exception e)
            {
                Driver.Quit();
                Console.WriteLine(e);
            }

        }

    }
}