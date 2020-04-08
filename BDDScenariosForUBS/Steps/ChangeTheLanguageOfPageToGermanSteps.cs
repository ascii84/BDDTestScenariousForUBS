using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Web;
using NUnit.Framework;
using TestsForUBSInterview.Pages;

namespace TestsForUBSInterview.Steps
{
    [Binding]
    public class ChangeTheLanguageOfPageToGermanSteps
    {
        private readonly IWebDriver _driver;

        public ChangeTheLanguageOfPageToGermanSteps(ScenarioContext scenarioContext)
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I have opened the main page")]
        public void GivenIHaveOpenedTheMainPage()
        {
            MainPObject mainPage = new MainPObject(_driver);
            mainPage.OpenMainPage();
        }

        [When(@"I click DE icon")]
        public void WhenIClickDEIcon()
        {
            MainPObject mainPage = new MainPObject(_driver);
            mainPage.ChangeLanguage();
        }
        
        [Then(@"The page is displayed in Germany version")]
        public void ThenThePageIsDisplayedInGermanyVersion()
        {
            string url = _driver.Url;
            Boolean isGermanSelected = url.Contains("de");
            Assert.IsTrue(isGermanSelected, "Language was not changed to German");
        }
    }
}
