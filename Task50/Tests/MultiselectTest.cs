using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Task50
{
    public class MultiselectTests
    {
        private ChromeDriver driver { get; set; }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SelectOptionsTest()
        {
            MultiselectPage multiselectPage = new MultiselectPage(driver);
            multiselectPage.SelectThreeOptions();
            multiselectPage.CheckTheAmountOfSelectedOptions(3);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}