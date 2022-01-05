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
