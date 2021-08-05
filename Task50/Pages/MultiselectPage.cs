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

        Random random = new Random();

        public SelectElement OptionsList()
        {
            SelectElement optionsList = new SelectElement(driver.FindElement(By.Id("multi-select")));
            return optionsList;
        }

        public MultiselectPage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl(url);
        }

        public void SelectThreeOptions()
        {
            int firstOption = random.Next(OptionsList().Options.Count);
            int secondOption = random.Next(OptionsList().Options.Count);
            int thirdOption = random.Next(OptionsList().Options.Count);

            OptionsList().SelectByIndex(firstOption);
            OptionsList().SelectByIndex(secondOption);
            OptionsList().SelectByIndex(thirdOption);
        }

        public void CheckTheAmountOfSelectedOptions(int expectedAmount)
        {
            Assert.AreEqual(expectedAmount, OptionsList().AllSelectedOptions.Count, "Seems more or less than 3 options are selected");
        }

    }

}

