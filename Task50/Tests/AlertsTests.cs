using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Task50
{
    class AlertsTests
    {
        private ChromeDriver driver { get; set; }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void AlertBoxAcceptedTest()
        {
            AlertsPage alertsPage = new AlertsPage(driver);
            alertsPage.AcceptAlertBox();
        }

        [Test]
        public void ConfirmBoxAcceptedTest()
        {
            AlertsPage alertsPage = new AlertsPage(driver);
            alertsPage.AcceptConfirmBox();
        }

        [Test]
        public void ConfirmBoxCancelledTest()
        {
            AlertsPage alertsPage = new AlertsPage(driver);
            alertsPage.DismissConfirmBox();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
