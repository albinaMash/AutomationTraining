using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using Task70.YandexPages;
using System;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace Task70
{
    class HomePage
    {

        private IWebDriver driver;
        private string url = "https://yandex.by/";
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Войти')]")]
        public IWebElement SigninButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'usermenu-link')]/a[1]/span")]
        public IWebElement UsernameLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#uniq289>span")]
        public IWebElement SignoutButton { get; set; }

        public void Open()
        {
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Яндекс", driver.Title);
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

        public void TakeScreenshot(string testCase)
        {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                var fileName = @"Screenshot " + testCase + " " + DateTime.Now.ToString("HH_mm_ss") + ".png";
                var fileLocation = Path.Combine(@"D:\Screenshots\", fileName);

                screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
        }
    }
}