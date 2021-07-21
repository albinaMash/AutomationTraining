using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Task50
{
    class TablePage
    {
        private string url = "https://www.seleniumeasy.com/test/table-sort-search-demo.html";
        private IWebDriver driver;

        public TablePage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl(url);
        }

        public void SelectDropdownItem()
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Name("example_length")));
            dropdown.SelectByValue("10");
            Assert.AreEqual(1, dropdown.AllSelectedOptions.Count);
        }

        public List <WebTable> ReturnObjects()
        {
            List<WebTable> objectsReturned = new List<WebTable>();
           
            IWebElement headerRow = driver.FindElement(By.XPath("//*[@id='example']/thead/tr"));
            IList<IWebElement> tableRows = headerRow.FindElements(By.TagName("tr"));
            IList<IWebElement> ageCells = driver.FindElements(By.XPath("//tr//td[4]"));
            IList<IWebElement> salaryCells = driver.FindElements(By.XPath("//tr//td[6]"));

            foreach (IWebElement row in tableRows)
            {
                foreach (IWebElement age in ageCells)
                    if (age.Text.Length > 1)
                    {
                        return objectsReturned;
                    }

                foreach (IWebElement salary in salaryCells)
                    if(salary.Text.Length > 5)
                    {
                        return objectsReturned;
                    }
            }

            return objectsReturned;
        }
    }
}
