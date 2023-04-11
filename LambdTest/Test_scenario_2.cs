using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Test_scenario_2
{

    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class TestSliderMoving<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            driver = new TWebDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
        }

        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
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
