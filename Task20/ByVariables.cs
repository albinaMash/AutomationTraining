using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task20
{
    class ByVariables
    {
        public static ChromeDriver Driver { get; private set; }

        public IWebElement signinByClassName = Driver.FindElementByClassName("desk-notif-card__login-new-item-title");
        public IWebElement signinByCssSelector = Driver.FindElementByCssSelector("class.desk-notif-card__login-new-item-title");
        public IWebElement loginFieldById = Driver.FindElementById("passp-field-login");
        public IWebElement loginFieldByName = Driver.FindElementByName("login");
        public IWebElement forgotPasswordByLink = Driver.FindElement(By.LinkText("Не помню"));
        public IWebElement forgotPasswordByPartialLink = Driver.FindElement(By.PartialLinkText("Не"));
        public IWebElement forgotPasswordByTag = Driver.FindElementByTagName("Did not find any tags on Yandex");
        public IWebElement loginFieldByXpath = Driver.FindElementByXPath("//*[@id='passp-field-login']");
    }
}
