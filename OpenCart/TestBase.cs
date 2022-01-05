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
        public IWebDriver driver;
        public WebDriverWait wait;
        public HomePage homePage;
        public LoginPage loginPage;
        public AccountPage accountPage;
        public RegisterPage registerPage;
        public ForgottenPasswordPage forgottenPasswordPage;

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
                case "chrome":
                    driver = new ChromeDriver();
                    break;
            }
            
            driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            accountPage = new AccountPage(driver);
            accountPage = new AccountPage(driver);
            registerPage = new RegisterPage(driver);
            forgottenPasswordPage = new ForgottenPasswordPage(driver);
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