using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace TestsForUBSInterview.Pages
{
    public class MainPObject
    {
        [FindsBy(How = How.XPath, Using = "(//li/a[@href='/global/de.html'])[1]")]
        protected IWebElement LanguageBtn { get; set; }

        [FindsBy(How = How.Id, Using = "menulabel-7001")]
        protected IWebElement UBSloginsBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='mainmenu']/li[4]/span[1]/a[1]")]
        protected IWebElement AboutUsMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='catNav__link'][contains(text(),'Our firm')]")]
        protected IWebElement OurFirmMenuItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//li/a[@id='menulabel-7338' and contains(.,'US client account login')]")]
        protected IWebElement USclientAccountLoginBtn { get; set; }

        private readonly IWebDriver _driver;

        public MainPObject(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        public MainPObject ChangeLanguage()
        {
            ClickLanguageButton();
            return this;
        }
        public MainPObject OpenLoginPage()
        {
            ClickUBSloginsButton();
            ClickUSClientAccoutLoginButton();
            return this;
        }
        public MainPObject OpenOurFirmPage()
        {
            ClickAboutUsMenu();
            ClickOurFirmMenuItem();
            return this;
        }
        public MainPObject OpenMainPage()
        {
            _driver.Navigate().GoToUrl("http://www.ubs.com");
            IWebElement detailFrame = _driver.FindElement(By.XPath("//iframe[@class='cboxIframe']"));
            _driver.SwitchTo().Frame(detailFrame);
            _driver.FindElement(By.XPath("//button[@name='senddata' and contains(.,'Agree to all')]")).Click();
            _driver.SwitchTo().ParentFrame();
            return this;
        }
        private void ClickLanguageButton()
        {          
            LanguageBtn.Click();
        }
        private void ClickUBSloginsButton()
        {
            UBSloginsBtn.Click();
        }
        private void ClickUSClientAccoutLoginButton()
        {
            USclientAccountLoginBtn.Click();
        }

        private void ClickAboutUsMenu()
        {
            AboutUsMenu.Click();
        }

        private void ClickOurFirmMenuItem()
        {
            OurFirmMenuItem.Click();
        }
    }
}