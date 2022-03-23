using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ProthomAloAutomationTest.Aggregates
{
    public class HelperClass
    {
        private readonly IWebDriver _driver;
        private int _zoomValue = 100;
        //private int ZoomIncrement = 10;
        public HelperClass(IWebDriver driver)
        {
            this._driver = driver;
            //_driver = new ChromeDriver();
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

        }

        public void ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            Thread.Sleep(ConstantClass.timeCount);
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

        }

        public void ScrollUp()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            Thread.Sleep(ConstantClass.timeCount);
            js.ExecuteScript("window.scrollTo(0, 0)");
        }

        public void ScrollToBottom()
        {
            long scrollHeight = 0;

            do
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                var newScrollHeight = (long)js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight); return document.body.scrollHeight;");

                if (newScrollHeight == scrollHeight)
                {
                    break;
                }
                else
                {
                    scrollHeight = newScrollHeight;
                    Thread.Sleep(400);
                }
            } while (true);
        }


        public void ZoomIn(int zoomIncrement)
        {
            _zoomValue += zoomIncrement;
            Zoom(_zoomValue);
        }
        public void ZoomNormal()
        {
            Zoom(_zoomValue);
        }
        public void ZoomOut(int zoomIncrement)
        {
            _zoomValue -= zoomIncrement;
            Zoom(_zoomValue);
        }
        private void Zoom(int level)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript(string.Format("document.body.style.zoom='{0}%'", level));
        }
    }
}