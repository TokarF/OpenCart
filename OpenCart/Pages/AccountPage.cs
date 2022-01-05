using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{
    public class AccountPage
    {
        readonly IWebDriver driver;
        string accountPageURL = "https://demo.opencart.com/index.php?route=account/account";

        public string AccountPageURL { get { return accountPageURL; } }
        
        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
