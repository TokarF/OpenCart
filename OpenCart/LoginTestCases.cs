using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{

    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTestCases : TestBase
    {

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void TestLoginWithValidUserCredentials(string browserName)
        {
            Setup(browserName);
            homePage.NavigateToLoginPage();
        }
    }
}
