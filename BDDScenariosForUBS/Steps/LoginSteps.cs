using OpenQA.Selenium;
using NUnit.Framework;
using TestsForUBSInterview.Pages;
using TechTalk.SpecFlow;

namespace TestsForUBSInterview.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        public LoginSteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I Navigate to the Login page for US client")]
        public void GivenINavigateToTheLoginPageForUSClient()
        {
            MainPObject mainPage = new MainPObject(_driver);
            LoginPObject loginPage = new LoginPObject(_driver);
            mainPage.OpenMainPage();
            mainPage.OpenLoginPage();
        }
   
        [When(@"I login with Username '(.*)' and Password '(.*)' on the Login Page")]
        public void WhenIUnsucessfullyLoginWithUsernameAndPasswordOnTheLoginPage(string username, string password)
        {
            LoginPObject loginPage = new LoginPObject(_driver);
            loginPage.LoginUnsuccessfullyAs(username, password);
        }

        [Then(@"I Should See Error Message '(.*)' displayed on the Login Page")]
        public void ThenIShouldSeeErrorMessageOnTheLoginPage(string errorMessage)
        {
            LoginPObject loginPage = new LoginPObject(_driver);
            string actualError = loginPage.GetErrorMessage();
            Assert.AreEqual(actualError, errorMessage, "Error message is not correct");
        }

    }
}
