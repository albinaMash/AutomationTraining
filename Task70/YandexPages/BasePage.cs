using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using Task70.YandexPages;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task70.YandexPages
{
    class BasePage
    {
        protected IWebDriver driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
