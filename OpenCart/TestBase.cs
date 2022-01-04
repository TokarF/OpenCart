using NUnit.Framework;
using OpenCart.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace OpenCart
{
    public class TestBase
    {
        internal IWebDriver driver;
        internal WebDriverWait wait;
        internal HomePage homePage;

        public void Setup(string browserName)
        {
            switch (browserName)
            {
                case "edge":
                    driver = new EdgeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "safari":
                    driver = new SafariDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            homePage = new HomePage(driver);

        }

        public static IEnumerable<string> BrowserToRunWith()
        {
            string[] browsers = Properties.Browsers.BrowserToRunWith.Split(",");

            foreach (string browser in browsers)
            {
                yield return browser;
            }
        }


        [TearDown]
        public void DerivedTearDown()
        {
            driver.Close();
        }
    }
}