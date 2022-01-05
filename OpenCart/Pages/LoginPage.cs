using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{
    public class LoginPage
    {
        readonly IWebDriver driver;
        private string loginPageTitle = "Account Login";
        private string loginPageURL = "https://demo.opencart.com/index.php?route=account/login";
        private string[] loginPageBreadCrumbLinksTexts = { "Account", "Login" };
        
        public string LoginPageTitle { get { return loginPageTitle; } }
        public string LoginPageURL { get { return loginPageURL; } }
        public string[] LoginPageBreadCrumbLinksTexts { get { return loginPageBreadCrumbLinksTexts; } }

        IWebElement EmailInput => driver.FindElement(By.XPath("//input[@name='email']"));
        IWebElement PasswordInput => driver.FindElement(By.Id("input-password"));
        IWebElement LoginBtn => driver.FindElement(By.XPath("//input[@value='Login']"));
        IWebElement NewCustomerBtn => driver.FindElement(By.XPath("//a[text()='Continue']"));
        IWebElement ForgottonPasswordLink => driver.FindElement(By.XPath("//form//a[text()='Forgotten Password']"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void FillLoginForm(string email, string password) 
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        } 

        public void ClickLoginBtn() => LoginBtn.Click();
        public void ClickNewCustomerBtn() => NewCustomerBtn.Click();
        public void ClickForgottonPasswordLink() => ForgottonPasswordLink.Click();


    }
}
