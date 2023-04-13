using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Test_scenario_2
{

    [TestFixture(typeof(ChromeDriver))]
    public class TestSimpleFormDemo<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        private IWebDriver driver;



        [SetUp]
        public void Setup()
        {
            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "111.0";
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("username", "levani.gmza.14");
            ltOptions.Add("accessKey", "GBiMovlPG3PUGB8tAL7FubhS4lPN6zBZDPQtKg8ChSXYy2CQXR");
            ltOptions.Add("platformName", "Windows 10");
            ltOptions.Add("project", "Untitled");
            ltOptions.Add("w3c", true);
            ltOptions.Add("plugin", "c#-c#");
            capabilities.AddAdditionalOption("LT:Options", ltOptions);


            driver = new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub"), capabilities.ToCapabilities());
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
            driver.FindElement(By.LinkText("Simple Form Demo")).Click();
        

            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
        }


        [Test]
        public void Slider_moving()
        {
            driver.FindElement(By.LinkText("Drag & Drop Sliders")).Click();

            IWebElement slider = driver.FindElement(By.CssSelector("#slider3 > div > input"));
            string currentValue = slider.GetAttribute("value");

            int sliderWidth = slider.Size.Width;
            int sliderValue = int.Parse(currentValue);
            int targetValue = 95;
            int distance = ((targetValue - sliderValue) * sliderWidth) / 100;

            Actions sliderAction = new Actions(driver);
            sliderAction.ClickAndHold(slider)
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .MoveByOffset(distance / 25, 0).Pause(TimeSpan.FromMilliseconds(100))
                .Release()
                .Perform();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => slider.GetAttribute("value") == targetValue.ToString());

            System.Threading.Thread.Sleep(5000);

            IWebElement rangeValue = driver.FindElement(By.Id("rangeSuccess"));
            Assert.AreEqual("95", rangeValue.GetAttribute("value"));
        }
    }
}
