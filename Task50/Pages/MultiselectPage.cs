using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task50
{
    class MultiselectPage
    {
        private string url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private IWebDriver driver;

        public MultiselectPage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl(url);
        }

        public void SelectThreeOptions()
        {
            SelectElement optionsList = new SelectElement(driver.FindElement(By.Id("multi-select")));

            Random random = new Random();

            int firstOption = random.Next(optionsList.Options.Count);
            int secondOption = random.Next(optionsList.Options.Count);
            int thirdOption = random.Next(optionsList.Options.Count);

            optionsList.SelectByIndex(firstOption);
            optionsList.SelectByIndex(secondOption);
            optionsList.SelectByIndex(thirdOption);

            Assert.AreEqual(3, optionsList.AllSelectedOptions.Count);
        }

    }

}

