using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Test_scenario_1
{
    [TestFixture]
    public class Test_scenario_1
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            driver = new ChromeDriver(path + @"\drivers\");
            driver.Manage().Window.Maximize();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
        }

        [Test]
        public void TestSimpleFormDemo()
        {

            driver.FindElement(By.LinkText("Simple Form Demo")).Click();

            Assert.IsTrue(driver.Url.Contains("simple-form-demo"));
            string message = "Welcome to LambdaTest";
            driver.FindElement(By.Id("user-message")).SendKeys(message);

            driver.FindElement(By.Id("showInput")).Click();

            Assert.AreEqual(message, driver.FindElement(By.Id("message")).Text);
        }



        [TearDown]
        public void Teardown()
        {

            driver.Quit();
        }
    }
}