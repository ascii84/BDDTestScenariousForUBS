using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestsForUBSInterview.Pages
{
    public class LoginPObject
    {
        [FindsBy(How = How.Id, Using = "username")]
        protected IWebElement UsernameTxtBox { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        protected IWebElement PasswordTxtBox { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        protected IWebElement LoginBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "notification-text")]
        protected IWebElement ErrorText { get; set; }

        private readonly IWebDriver _driver;

        public LoginPObject(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
  
        public LoginPObject LoginUnsuccessfullyAs(string username, string password)
        {
            Login(username, password);
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("notification-text")));
            return this;
        }

        public string GetErrorMessage()
        {
            return ErrorText.Text;
        }

        private void Login(string username, string password)
        {
            UsernameTxtBox.SendKeys(username);
            PasswordTxtBox.SendKeys(password);
            LoginBtn.Click();
        }
    }
}