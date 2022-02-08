using Bogus;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{

    [TestFixture(Description = "Validate register functionality")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RegisterFunctionality : TestBase
    {

        [Test(Description = "Validate registration with filling out all mandatory fields with valid data")]
        public void RF_TC_001([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName)
        {
            Setup(browserName);
            homePage.NavigateToRegisterPage();

            Faker faker = new Faker();

            string passWord = faker.Internet.Password();

            registerPage.FillRegisterForm(faker.Person.FirstName, faker.Person.LastName, faker.Person.Email, faker.Person.Phone, passWord, passWord);

            registerPage.CheckPrivacyPolicyCb();

            registerPage.ClickRegisterBtn();

            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Is.EqualTo(registerPage.RegisterSuccessPageURL));
                Assert.That(driver.FindElement(By.XPath("//div[@id='content']/h1[text()='Your Account Has Been Created!']")).Displayed, Is.True);
            });
        }


        [Test(Description = "Validate registration input fields validation rules messages")]
        public void RF_TC_002([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName)
        {
            Setup(browserName);
            homePage.NavigateToRegisterPage();

            registerPage.ClickRegisterBtn();

            Assert.That(registerPage.GetErrors(new[] { "firstNameLengthError", "lastNameLengthError, emailLengthError, telephoneLengthError, passwordLengthError" }).All(x => x.Displayed), Is.True);
        }

        [Test(Description = "Check First Name and Last name fields validation rules works properly on the registration page")]
        public void RF_TC_003([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName, [ValueSource(nameof(InvalidNameInputs))] string name)
        {
            Setup(browserName);
            homePage.NavigateToRegisterPage();

            Faker faker = new Faker();

            string passWord = faker.Internet.Password();


            registerPage.FirstNameInput.Clear();
            registerPage.FirstNameInput.SendKeys(name);

            registerPage.LastNameInput.Clear();
            registerPage.LastNameInput.SendKeys(name);

            registerPage.CheckPrivacyPolicyCb();

            registerPage.ClickRegisterBtn();

            Assert.That(registerPage.GetErrors(new[] { "firstNameLengthError", "lastNameLengthError" }).All(x => x.Displayed), Is.True);


     
        }

        [Test(Description = "Check Email field validation rules works properly on the registration page")]
        public void RF_TC_004([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName, [ValueSource(nameof(InvalidEmailInputs))] string email)
        {
            Setup(browserName);
            homePage.NavigateToRegisterPage();

            registerPage.EmailInput.Clear();
            registerPage.EmailInput.SendKeys(email);

            registerPage.CheckPrivacyPolicyCb();

            registerPage.ClickRegisterBtn();

            Assert.That(registerPage.GetErrors(new[] { "emailValidError" }).All(x => x.Displayed), Is.True);

        }

        [Test(Description = "Check Telephone field validation rules works properly on the registration page")]
        public void RF_TC_005([ValueSource(typeof(TestBase), "BrowserToRunWith")] string browserName, [ValueSource(nameof(InvalidTelephoneInputs))] string telephone)
        {
            Setup(browserName);
            homePage.NavigateToRegisterPage();

            registerPage.TelephoneInput.Clear();
            registerPage.TelephoneInput.SendKeys(telephone);

            registerPage.CheckPrivacyPolicyCb();

            registerPage.ClickRegisterBtn();

            Assert.That(registerPage.GetErrors(new[] { "telephoneLengthError", "telephoneValidError" }).Any(x => x.Displayed), Is.True);
       

        }

        private static IEnumerable<string> InvalidNameInputs => new[] { "", "   ", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"};
        private static IEnumerable<string> InvalidEmailInputs => new[] { "test@com" };
        private static IEnumerable<string> InvalidTelephoneInputs => new[] { "1" , "111111111111111111111111111111111", "one" };
    }
}
