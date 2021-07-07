using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task70.YandexPages
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "passp-field-login")]
        public IWebElement LoginField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement LoginButton { get; set; }

        public void EnterUsername(string username)
        {
            LoginField.SendKeys(username);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }
    }
}
