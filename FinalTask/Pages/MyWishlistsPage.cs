using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using Allure.NUnit.Attributes;
using System.Collections.Generic;

namespace FinalTask.Pages
{
    class MyWishlistsPage : BasePage
    {

        public MyWishlistsPage(IWebDriver driver) : base (driver)
        {
        }

        [FindsBy(How = How.ClassName, Using = "product-name")]
        public IWebElement ProductNameLink
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "block-history")]
        public IWebElement WishlistsTable
        {
            get; set;
        }

        [FindsBy(How = How.CssSelector, Using = "tr[id]")]
        public IWebElement WishlistRow
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement WishlistNameField
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "submitWishlist")]
        public IWebElement SaveWishlistButton
        {
            get; set;
        }

        [AllureStep("Check default state of wishlist page for new user")]
        public void CheckWishlistEmpty()
        {
            Assert.False(WishlistsTable.Displayed);
        }

        [AllureStep("Open some product page in order to add it to wishlist")]
        public void ClickProductLink()
        {
            ProductNameLink.Click();
        }

        [AllureStep("Verify that wishlist is created automatically after adding an item")]
        public void CheckWishlistCreatedAutomatically()
        {
            IWebElement headerRow = driver.FindElement(By.XPath("//*[@id='example']/thead/tr"));
            IList<IWebElement> tableRows = headerRow.FindElements(By.TagName("tr"));

            Assert.AreEqual(1, tableRows.Count, "Wishlist is not created automatically");
        }

        public void DeleteCraetedWishlist()
        {
            IWebElement removeIcon = driver.FindElement(By.ClassName("icon-remove"));
            removeIcon.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            Assert.False(WishlistRow.Displayed, "Wishlist is not deleted");
        }

        [AllureStep("Add new wishlist manually")]
        public void CreateNewWishlistManually()
        {
            WishlistNameField.SendKeys("test");
            SaveWishlistButton.Click();
        }

        [AllureStep("Check new wishlist created manually")]
        public void VerifyWishlistCreatedManually()
        {
            IWebElement headerRow = driver.FindElement(By.XPath("//table/thead/tr"));
            IList<IWebElement> tableRows = headerRow.FindElements(By.TagName("//tbody/tr"));

            Assert.AreEqual(1, tableRows.Count, "Wishlist is not created manually");
        }

        [AllureStep("Check if quantity is changed after adding one product")]
        public void CheckQuantityOfProductsAdded(int expectedProductAmount)
        {
            var quantityCell = driver.FindElement(By.XPath("//td[2]"));

            Assert.AreEqual(expectedProductAmount, quantityCell.Text, "Expected count does not correspond to actual");
        }
    }
}
