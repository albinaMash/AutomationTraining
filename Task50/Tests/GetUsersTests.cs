using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Task50
{
    class GetUserTests
    {
        private ChromeDriver driver { get; set; }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void UserInfoIsDisplayed()
        {
            GetUserPage getUserPage = new GetUserPage(driver);
            getUserPage.WaitForUserToBeDisplayed();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}