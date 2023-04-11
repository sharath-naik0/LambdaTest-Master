using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Test_scenario_1
{

    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]

    public class TestSimpleFormDemo<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
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