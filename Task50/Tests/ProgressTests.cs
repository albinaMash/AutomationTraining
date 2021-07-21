using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Task50
{
    public class ProgressTests
    {
        private ChromeDriver driver { get; set; }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void RefreshPageWithCondition()
        {
            ProgressPage progressPage = new ProgressPage(driver);
            progressPage.RefreshPage();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
