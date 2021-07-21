using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task50
{
    class YandexPage
    {
        private string url = "https://yandex.by/";
        private IWebDriver driver;
        private IWebElement signinButton;
        private IWebElement loginButton;
        private IWebElement loginButton2;
        private IWebElement loginField;

        public YandexPage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl(url);
        }

        public void Login(string username, string password)
        {
            signinButton = driver.FindElement(By.ClassName("desk-notif-card__login-new-item-title"));
            signinButton.Click();

            loginField = driver.FindElement(By.Id("passp-field-login"));
            loginField.SendKeys(username);

            loginButton = driver.FindElement(By.XPath("//button"));
            loginButton.Click();

            var passwordField = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            passwordField.Until(ExpectedConditions.ElementToBeClickable(By.Id("passp-field-passwd"))).SendKeys(password);

            loginButton2 = driver.FindElement(By.XPath("//button[contains(@class, 'Button2_type_submit')]"));
            loginButton2.Click();
        }

        public void WaitForUsername()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var username = wait.Until(condition =>
            {
                try
                {
                    var usernameDisplayed = driver.FindElement(By.XPath("//span[contains(@class, 'user - name')]"));
                    return usernameDisplayed.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            );
        }
    }
}