using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task50
{
    class AlertsPage
    {
        private string url = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        private IWebDriver driver;
        private IWebElement alertClickMeButton;
        private IWebElement confirmClickMeButton;
        private IAlert alert;
        private string alertText;

        public AlertsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl(url);
        }

        public void AcceptAlertBox()
        {
            alertClickMeButton = driver.FindElement(By.XPath("//button[contains(@class, 'btn btn-default')]"));
            alertClickMeButton.Click();

            alert = driver.SwitchTo().Alert();
            alertText = alert.Text;

            Assert.AreEqual("I am an alert box!", alertText);

            alert.Accept();

            Assert.IsNotNull(alertClickMeButton);
        }

        public void AcceptConfirmBox()
        {
            confirmClickMeButton = driver.FindElement(By.XPath("//button[contains(@class, 'btn btn-default btn-lg')]"));
            confirmClickMeButton.Click();

            alert = driver.SwitchTo().Alert();
            alertText = alert.Text;

            Assert.AreEqual("Press a button!", alertText);

            bool accepted() { alert.Accept(); return true; }

            Assert.IsTrue(accepted());
        }

        public void DismissConfirmBox()
        {
            confirmClickMeButton = driver.FindElement(By.XPath("//button[contains(@class, 'btn btn-default btn-lg')]"));
            confirmClickMeButton.Click();

            alert = driver.SwitchTo().Alert();
            alertText = alert.Text;

            Assert.AreEqual("Press a button!", alertText);

            bool cancelled() { alert.Dismiss(); return false; }

            Assert.IsFalse(cancelled());
        }
    }
}
