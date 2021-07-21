using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Allure.NUnit.Attributes;

namespace FinalTask.Pages
{
    class ProductPage : BasePage
    {

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "wishlist_button")]
        public IWebElement AddToWishlistButton
        {
            get; set;
        }

        [AllureStep("Add product to wishlist from product page")]
        public void ClickAddToWishlist()
        {
            AddToWishlistButton.Click();
        }
    }
}

