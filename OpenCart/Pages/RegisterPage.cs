using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{
    public struct RegisterPageErorrs
    {
        private string telephoneLengthError = "//div[@class='text-danger' and contains(., 'Telephone must be between 3 and 32 characters!')]";

        public string TelephoneLengthError { get => telephoneLengthError; set => telephoneLengthError = value; }
    }



    public class RegisterPage
    {
        readonly IWebDriver driver;
        private string registerPageTitle = "Register Account";
        private string registerPageURL = "https://demo.opencart.com/index.php?route=account/register";
        private string[] registerPageBreadCrumbLinksTexts = { "Account", "Register" };
        private string registerSuccessPageURL = "https://demo.opencart.com/index.php?route=account/success";
        private RegisterPageErorrs registerPageErrors; 

        public string RegisterPageTitle { get { return registerPageTitle; } }
        public string RegisterPageURL { get { return registerPageURL; } }
        public string RegisterSuccessPageURL { get { return registerSuccessPageURL; } }
        public string[] RegisterPageBreadCrumbLinksTexts { get { return registerPageBreadCrumbLinksTexts; } }

        public IWebElement FirstNameInput => driver.FindElement(By.XPath("//input[@name='firstname']"));
        public IWebElement LastNameInput => driver.FindElement(By.XPath("//input[@name='lastname']"));
        public IWebElement EmailInput => driver.FindElement(By.XPath("//input[@name='email']"));
        public IWebElement TelephoneInput => driver.FindElement(By.XPath("//input[@name='telephone']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@name='password']"));
        public IWebElement PasswordConfirmInput => driver.FindElement(By.XPath("//input[@name='confirm']"));
        public IWebElement PrivacyPolicyCheckBox => driver.FindElement(By.XPath("//input[@name='agree']"));
        public ICollection<IWebElement> NewsLetterRadioButtons => driver.FindElements(By.XPath("//input[@name='newsletter']"));
        public IWebElement RegisterBtn => driver.FindElement(By.XPath("//input[@value='Continue' and @type='submit']"));
        public RegisterPageErorrs RegisterPageErrors { get => registerPageErrors; set => registerPageErrors = value; }

        public List<KeyValuePair<string, string>> ErrorMessages => new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("telephoneLengthError", "//div[@class='text-danger' and contains(., 'Telephone must be between 3 and 32 characters!')]"),
            new KeyValuePair<string, string>("telephoneValidError", "//div[@class='text-danger' and contains(., 'Telephone does not appear to be valid!')]"),
            new KeyValuePair<string, string>("firstNameLengthError", "//div[@class='text-danger' and contains(., 'First Name must be between 1 and 32 characters!')]"),
            new KeyValuePair<string, string>("lastNameLengthError", "//div[@class='text-danger' and contains(., 'Last Name must be between 1 and 32 characters!')]"),
            new KeyValuePair<string, string>("emailValidError", "//div[@class='text-danger' and contains(., 'E-Mail Address does not appear to be valid!')]')]"),
            new KeyValuePair<string, string>("passwordLengthError", "//div[@class='text-danger' and contains(., 'Password must be between 4 and 20 characters!')]"),
        };


        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FillRegisterForm(string firstName, string lastName, string email, string telephone, string password, string passwordConfirm)
        {
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(firstName);

            LastNameInput.Clear();
            LastNameInput.SendKeys(lastName);

            EmailInput.Clear();
            EmailInput.SendKeys(email);

            TelephoneInput.Clear();
            TelephoneInput.SendKeys(telephone);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            PasswordConfirmInput.Clear();
            PasswordConfirmInput.SendKeys(passwordConfirm);
        }

        public List<IWebElement> GetErrors(string[] expectedErrors)
        {
            List<IWebElement> errors = new List<IWebElement>();

            foreach (string expectedError in expectedErrors)
            {
                try
                {
                   errors.Add(driver.FindElement(By.XPath(ErrorMessages.First(x => x.Key == expectedError).Value)));
                }
                catch (NoSuchElementException)
                {
                    continue;
                }
            }

            return errors;
        }

        public void CheckPrivacyPolicyCb() => PrivacyPolicyCheckBox.Click();
        public void ClickRegisterBtn() => RegisterBtn.Click();

    }
}
