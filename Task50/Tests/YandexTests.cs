using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace Task50
{
    public class YandexTests
    {
        private ChromeDriver driver { get; set; }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
        [Parallelizable(ParallelScope.All)]
        public void LoginAndWaitUsernameTest(string username, string password)
        {
            YandexPage yandexPage = new YandexPage(driver);

            yandexPage.Login(username, password);
            yandexPage.WaitForUsername();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}