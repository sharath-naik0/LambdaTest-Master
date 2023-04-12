using NUnit.Framework;
using OpenQA.Selenium;
using static System.Environment;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Test_scenario_1
{

    [TestFixture(typeof(ChromeDriver))]
   // [TestFixture(typeof(FirefoxDriver))]

    public class TestSimpleFormDemo<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest()

        {
            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "111.0";
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("username", "levani.gmza.14");
            ltOptions.Add("accessKey", "GBiMovlPG3PUGB8tAL7FubhS4lPN6zBZDPQtKg8ChSXYy2CQXR");
            ltOptions.Add("visual", true);
            ltOptions.Add("video", true);
            ltOptions.Add("platformName", "Windows 10");
            ltOptions.Add("build", "LambdaTest");
            ltOptions.Add("project", "LambdaTest");
            ltOptions.Add("name", "Test_scenario_1");
            ltOptions.Add("tunnel", true);
            ltOptions.Add("w3c", true);
            ltOptions.Add("plugin", "c#-nunit");



            capabilities.AddAdditionalOption("LT:Options", ltOptions);
            driver = new TWebDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
            driver.FindElement(By.LinkText("Simple Form Demo")).Click();
        }

        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
        }

        [Test]
        public void TestSimpleFormDemoWithDifferentBrowsers()
        {
            Assert.IsTrue(driver.Url.Contains("simple-form-demo"));
            string message = "Welcome to LambdaTest";
            driver.FindElement(By.Id("user-message")).SendKeys(message);

            driver.FindElement(By.Id("showInput")).Click();

            Assert.AreEqual(message, driver.FindElement(By.Id("message")).Text);
        }
    }
}