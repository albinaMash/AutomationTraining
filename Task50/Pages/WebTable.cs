using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Task50
{
    public class WebTable
    {
        private IWebDriver driver;
        private IWebElement webTable;
        private IWebElement name;
        private IWebElement position;
        private IWebElement office;

        public WebTable(IWebElement webTable)
        {
            this.webTable = webTable;
            driver.FindElement(By.CssSelector("table#example"));
        }

        public IWebElement Name
        {
            get { return name; }
            set { name = driver.FindElement(By.ClassName("sorting_1")); }
        }

        public IWebElement Position
        {
            get { return position; }
            set { position = driver.FindElement(By.XPath("//tr//td[2]")); }
        }

        public IWebElement Office
        {
            get { return office; }
            set { office = driver.FindElement(By.XPath("//tr//td[3]")); }
        }
    }
}