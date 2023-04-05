using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Test_scenario_3
{
   
        [TestFixture]
        public class Test_scenario_3
        {
            private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            driver = new ChromeDriver(path + @"\drivers\");
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

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
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


            Thread.Sleep(1000);


             IWebElement element1 = driver.FindElement(By.Id("exit_popup_close"));

            if (element1.Displayed)
            {
                element1.Click();
            }
            else
            {
                driver.FindElement(By.CssSelector("#seleniumform > div.text-right.mt-20 > button")).Click();
            }

 
            IWebElement success = driver.FindElement(By.CssSelector("#__next > div.wrapper > section.mt-50 > div > div > div.w-8\\/12.smtablet\\:w-full.px-15.smtablet\\:mt-20 > div > p"));
             Assert.AreEqual("Thanks for contacting us, we will get back to you shortly.", success.Text);
            

            driver.Quit();

            




        }



    }
}