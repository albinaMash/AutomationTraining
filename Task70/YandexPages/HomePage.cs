using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using Task70.YandexPages;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task70
{
    class HomePage : BasePage
    { 
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        private string url = "https://yandex.by/";
        private string expectedPageTitle = "Яндекс";

        [FindsBy(How=How.XPath, Using = "//div[contains(text(), 'Войти')]")]
        public IWebElement SigninButton { get; set; }

        [FindsBy(How= How.XPath, Using = "//div[contains(@class, 'usermenu-link')]/a[1]/span")]
        public IWebElement UsernameLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='uniq269']/span")]
        public IWebElement SignoutButton { get; set; }

        public void Open()
        {
            driver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists((By.TagName("title"))));
            Assert.AreEqual(expectedPageTitle, driver.Title);
        }
        public void ClickSigninButton()
        {
            SigninButton.Click();
        }

        public void ClickUsernameLink()
        {
            UsernameLink.Click();
        }

        public void ClickSignoutButton()
        {
            SignoutButton.Click();
        }

        public void CheckUserIsSignedOut()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeSelected(SignoutButton));
            Assert.IsNotNull(SignoutButton, "Seems the user did not sign out");
        }

        public void Login(string username, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            PasswordPage passwordPage = new PasswordPage(driver);

            ClickSigninButton();

            loginPage.EnterUsername(username);
            loginPage.ClickLoginButton();

            passwordPage.EnterPassword(password);
            passwordPage.ClickLoginButton();
        }

        public void CheckUserIsLoggedin()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeSelected(UsernameLink));
            Assert.IsNotNull(UsernameLink, "Seems user is not logged in");
        }
    }
}
