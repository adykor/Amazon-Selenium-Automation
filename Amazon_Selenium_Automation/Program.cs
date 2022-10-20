using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Automation
{
    class Program
    {

        // Create a reference for Chrome browser
        IWebDriver driver = new ChromeDriver();

        //static void Main(string[] args)
        //{
        //}

        [SetUp]
        public void Initialize()
        {
            // Go to Amazon page
            driver.Navigate().GoToUrl("https://www.amazon.com");
        }


        [Test]
        public void ExecuteTest()
        {
            // Make the browser full screen
            driver.Manage().Window.Maximize();

            // Web elements & their respective operations
            IWebElement SignIn = driver.FindElement(By.Id("nav-link-accountList"));
            SignIn.Click();

            IWebElement EmailField = driver.FindElement(By.Id("ap_email"));
            EmailField.SendKeys("mysweetstyle@it.moss");

            IWebElement ContinueButton = driver.FindElement(By.Id("continue"));
            ContinueButton.Click();

            IWebElement ErrorMessage = driver.FindElement(By.ClassName("a-alert-heading"));

            // Assertion variables
            string ActualErrorMessageText = ErrorMessage.Text;
            string ExpectedErrorMessageText = "There was a problem";

            // Assertion
            Assert.AreEqual(ActualErrorMessageText, ExpectedErrorMessageText);
        }


        [TearDown]
        public void CloseTest()
        {
            // Close the browswer
            driver.Quit();
        }

    }
}

