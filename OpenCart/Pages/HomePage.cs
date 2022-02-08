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
        private string homePageURL = "https://demo.opencart.com/";

        public string HomePageURL { get { return homePageURL; } }
        public IWebElement MyAccountLink => driver.FindElement(By.XPath("//a[@title='My Account']"));
        public IWebElement LoginLink => driver.FindElement(By.LinkText("Login"));
        public IWebElement RegisterLink => driver.FindElement(By.LinkText("Register"));


        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToLoginPage()
        {
            driver.Navigate().GoToUrl(homePageURL);
            MyAccountLink.Click();
            LoginLink.Click();
        }

        public void NavigateToRegisterPage()
        {
            driver.Navigate().GoToUrl(homePageURL);
            MyAccountLink.Click();
            RegisterLink.Click();
        }

        public List<string> GetBreadCrumbLinksTexts()
        {
            ICollection<IWebElement> breadCrumbLinks = driver.FindElements(By.XPath("//*[contains(@class, 'breadcrumb')]/li/a"));

            List<string> breadCrumbLinksTexts = new List<string>();

            foreach (var breadcrumbLink in breadCrumbLinks)
            {
                if (breadcrumbLink.Text != string.Empty)
                {
                    breadCrumbLinksTexts.Add(breadcrumbLink.Text);
                }
            }

            return breadCrumbLinksTexts;
        }


    }
}
