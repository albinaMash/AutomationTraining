using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Task50
{
    class TableTests
    {
        private ChromeDriver driver { get; set; }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        
        [Test]
        public void TableRowsReturningTest()
        {
            TablePage tablePage = new TablePage(driver);
            tablePage.SelectDropdownItem();
            tablePage.ReturnObjects();
        }
    }
}
