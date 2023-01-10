using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace GoogleUITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SearchTextMatch()
        {
            int waitingTime = 2000;

            By googleSearchBar = By.Name("q");
            By googleSearchButton = By.Name("btnK");
            By googleResultText = By.XPath(".//div[@data-attrid='title']");
            //By googleIAgreeButton = By.Id("L2AGLb");

            IWebDriver webDriver = new ChromeDriver();
            Thread.Sleep(waitingTime);


            webDriver.Navigate().GoToUrl("https://www.google.com/");
            Thread.Sleep(waitingTime);

            //webDriver.FindElement(googleIAgreeButton).Click();
            webDriver.Manage().Window.Maximize();
            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchBar).SendKeys("Street Fighter V");
            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchButton).Click();
            Thread.Sleep(waitingTime);

            var actualResultText = webDriver.FindElement(googleResultText);

            Assert.IsTrue(actualResultText.Text.Equals("Street Fighter V"));

            webDriver.Quit();
        }
    }
}
