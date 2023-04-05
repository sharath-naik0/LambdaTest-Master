using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;

namespace Test_scenario_2
{
    [TestFixture]
    public class Test_scenario_2
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            driver = new ChromeDriver(path + @"\drivers\");
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestScenario2()
        {
            driver.FindElement(By.LinkText("Drag & Drop Sliders")).Click();

            IWebElement slider = driver.FindElement(By.CssSelector("#slider3 > div > input"));
            string currentValue = slider.GetAttribute("value");

            int sliderWidth = slider.Size.Width;
            int sliderValue = int.Parse(currentValue);
            int targetValue = 95;
            int distance = ((targetValue - sliderValue) * sliderWidth) / 100;

            // Move the slider step by step until it reaches the target value
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

            Thread.Sleep(5000);



            IWebElement rangeValue = driver.FindElement(By.Id("rangeSuccess"));
            Assert.AreEqual("95", rangeValue.GetAttribute("value"));


        }
    }
}