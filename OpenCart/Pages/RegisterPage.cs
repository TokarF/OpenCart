using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{
    public class RegisterPage
    {
        readonly IWebDriver driver;
        private string registerPageTitle = "Register Account";
        private string registerPageURL = "https://demo.opencart.com/index.php?route=account/register";
        private string[] registerPageBreadCrumbLinksTexts = { "Account", "Register" };

        public string RegisterPageTitle { get { return registerPageTitle; } }
        public string RegisterPageURL { get { return registerPageURL; } }
        public string[] RegisterPageBreadCrumbLinksTexts { get { return registerPageBreadCrumbLinksTexts; } }

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
