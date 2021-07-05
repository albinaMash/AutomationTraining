using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Task20
{
    public class YandexByTests
    {
        public static ChromeDriver Driver { get; private set; }

        //Define elements to interact
        public IWebElement siginButton;
        public IWebElement loginField;
        public IWebElement loginButton;
        public IWebElement passwordField;
        public IWebElement loginButton2;

        //Define reusable values
        public string yandexUrl = "https://yandex.by";
        public string login = "AutomationTask20";
        public string password = "AutomationTraining";
        public string expectedPage = "яндекс";

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [Test]
        public void YandexSuccessfulLoginTest()
        {
            Driver.Navigate().GoToUrl(yandexUrl);
            siginButton = Driver.FindElement(By.ClassName("desk-notif-card__login-new-item-title"));
            siginButton.Click();
            loginField = Driver.FindElement(By.Id("passp-field-login"));
            loginField.Click();
            loginField.SendKeys(login);
            loginButton = Driver.FindElement(By.XPath("//button"));
            loginButton.Click();
            var passwordField = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            passwordField.Until(ExpectedConditions.ElementToBeClickable(By.Id("passp-field-passwd"))).SendKeys(password);
            loginButton2 = Driver.FindElement(By.XPath("//*[@class='Button2 Button2_size_l Button2_view_action Button2_width_max Button2_type_submit']"));
            loginButton2.Click();
            var page = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            page.Until(ExpectedConditions.TitleIs("яндекс"));
            Assert.AreEqual(expectedPage, Driver.Title, "It seems you are not signed in successfuly");
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
    
}