using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{

    [TestFixture(Description = "Validate login functionality")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginFunctionality : TestBase
    {

        [Test(Description = "Check login functionality with valid login data")]
        public void LF_TC_001([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName)
        {
            Setup(browserName);
            homePage.NavigateToLoginPage();
            loginPage.FillLoginForm(Environment.GetEnvironmentVariable("Email"), Environment.GetEnvironmentVariable("Password"));
            loginPage.ClickLoginBtn();

            Assert.That(driver.Url, Is.EqualTo(accountPage.AccountPageURL));
        }

        [Test(Description = "Validate login functionality with invalid email and password")]
        public void LF_TC_002([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName)
        {
            Setup(browserName);
            homePage.NavigateToLoginPage();
            loginPage.FillLoginForm("email", "password");
            loginPage.ClickLoginBtn();

            Assert.That(driver.FindElement(By.XPath("//*[text()=' Warning: No match for E-Mail Address and/or Password.']")).Displayed, Is.True);
        }

        [Test(Description = "Validate login functionality with valid email and invalid password")]
        public void LF_TC_003([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName)
        {
            Setup(browserName);
            homePage.NavigateToLoginPage();
            loginPage.FillLoginForm(Environment.GetEnvironmentVariable("Email"), "password");
            loginPage.ClickLoginBtn();

            Assert.That(driver.FindElement(By.XPath("//*[text()=' Warning: No match for E-Mail Address and/or Password.']")).Displayed, Is.True);
        }

        [Test(Description = "Validate login functionality with invalid email and valid password")]
        public void LF_TC_004([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName)
        {
            Setup(browserName);
            homePage.NavigateToLoginPage();
            loginPage.FillLoginForm("email", Environment.GetEnvironmentVariable("Password"));
            loginPage.ClickLoginBtn();

            Assert.That(driver.FindElement(By.XPath("//*[text()=' Warning: No match for E-Mail Address and/or Password.']")).Displayed, Is.True);
        }

        [Test(Description = "Check New Customer link works properly on Login page")]
        public void LF_TC_005([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName)
        {
            Setup(browserName);
            homePage.NavigateToLoginPage();
            loginPage.ClickNewCustomerBtn();

            Assert.That(driver.Url, Is.EqualTo(registerPage.RegisterPageURL));
        }

        [Test(Description = "Check Forgotton password link works properly on Login page")]
        public void LF_TC_006([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName)
        {
            Setup(browserName);
            homePage.NavigateToLoginPage();
            loginPage.ClickForgottonPasswordLink();

            Assert.That(driver.Url, Is.EqualTo(forgottenPasswordPage.ForgottenPasswordPageURL));
        }


        [Test(Description = "ValidateValidate page title, breadcrumb links and url are proper on the Login page")]
        public void LF_TC_007([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName)
        {
            Setup(browserName);
            homePage.NavigateToLoginPage();

            Assert.Multiple(() => 
            {
                Assert.That(driver.Title, Is.EqualTo(loginPage.LoginPageTitle));
                Assert.That(driver.Url, Is.EqualTo(loginPage.LoginPageURL));
                Assert.That(homePage.GetBreadCrumbLinksTexts(), Is.SupersetOf(loginPage.LoginPageBreadCrumbLinksTexts));
            });
        }


    }
}
