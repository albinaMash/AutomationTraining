using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Task70.YandexPages
{
    class PasswordPage
    {
        private IWebDriver driver;
        public PasswordPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "passp-field-passwd")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement Login2Button { get; set; }

        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            Login2Button.Click();
        }
    }
}
