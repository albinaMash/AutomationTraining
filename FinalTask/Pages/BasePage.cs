using OpenQA.Selenium;

namespace FinalTask.Pages
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
