using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{
    public class ForgottenPasswordPage
    {
        readonly IWebDriver driver;
        private string forgottenPasswordPageTitle = "Forgot Your Password?";
        private string forgottenPasswordPageURL = "https://demo.opencart.com/index.php?route=account/forgotten";
        private string[] forgottenPasswordPageBreadCrumbLinksTexts = { "Account", "Forgotten" };

        public string ForgottenPasswordPageTitle { get { return forgottenPasswordPageTitle; } }
        public string ForgottenPasswordPageURL { get { return forgottenPasswordPageURL; } }
        public string[] ForgottenPasswordPageBreadCrumbLinksTexts { get { return forgottenPasswordPageBreadCrumbLinksTexts; } }

        public ForgottenPasswordPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
