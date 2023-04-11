using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace Test_scenario_3
{

    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class Test_scenario_3
    {
        private IWebDriver driver;
        private string browser;

        public Test_scenario_3(string browser)
        {
            this.browser = browser;
        }

        [SetUp]
        public void Setup()
        {
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground");
            driver.FindElement(By.LinkText("Input Form Submit")).Click();
        }

        [Test]
        public void A1_Submit_without_filling()
        {
            driver.FindElement(By.CssSelector("#seleniumform > div.text-right.mt-20 > button")).Click();

            IWebElement error = driver.FindElement(By.CssSelector("input:invalid"));
            Assert.AreEqual("Please fill in the fields", error.Text);
        }

        [Test]
        public void A2_Submit_With_filled_data()
        {
            driver.FindElement(By.Id("name")).SendKeys("Levani Gamezardashvili ");
            driver.FindElement(By.Id("inputEmail4")).SendKeys("Levani.gmz.14@gmail.com");
            driver.FindElement(By.Id("inputPassword4")).SendKeys("Aa89586858");
            driver.FindElement(By.Id("company")).SendKeys("Levani_Holding");
            driver.FindElement(By.Id("websitename")).SendKeys("www.Levani_Holding.ge");
            driver.FindElement(By.Id("inputCity")).SendKeys("Tbilisi");
            driver.FindElement(By.Id("inputAddress1")).SendKeys("Gorgasali_street");
            driver.FindElement(By.Id("inputAddress2")).SendKeys("street_44");
            driver.FindElement(By.Id("inputState")).SendKeys("Tbilisi");
            driver.FindElement(By.Id("inputZip")).SendKeys("20220");

            IWebElement country = driver.FindElement(By.CssSelector("#seleniumform > div:nth-child(3) > div.form-group.w-6\\/12.smtablet\\:w-full.pr-20.smtablet\\:pr-0 > select"));
            SelectElement select = new SelectElement(country);
            select.SelectByText("United States");


            Thread.Sleep(1400);



            IWebElement elementB = driver.FindElement(By.CssSelector("#seleniumform > div.text-right.mt-20 > button"));
            elementB.Click();


            Thread.Sleep(1000);

            IWebElement success = driver.FindElement(By.CssSelector("#__next > div.wrapper > section.mt-50 > div > div > div.w-8\\/12.smtablet\\:w-full.px-15.smtablet\\:mt-20 > div > p"));
            Assert.AreEqual("Thanks for contacting us, we will get back to you shortly.", success.Text);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }



    }
}