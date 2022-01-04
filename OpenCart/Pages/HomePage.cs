using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{
    public class HomePage
    {
        readonly IWebDriver driver;

        string homePageURL = "https://demo.opencart.com/";
        IWebElement myAccountLink => driver.FindElement(By.XPath("//a[@title='My Account']"));
        IWebElement linkLogin => driver.FindElement(By.LinkText("Login"));


        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToLoginPage()
        {
            driver.Navigate().GoToUrl(homePageURL);
            myAccountLink.Click();
            linkLogin.Click();
        }


    }
}
