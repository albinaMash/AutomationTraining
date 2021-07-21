using NUnit.Framework;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using FinalTask.Pages;

namespace FinalTask.Tests
{
    [TestFixture]
    [Parallelizable]
    [TestFixture("crome", "latest", "Windows 10")]
    [TestFixture("firefox", "latest", "Windows 10")]
    class CartTests : BaseTest
    {
        public CartTests(string browser, string version, string os) : base(browser, version, os)
        {
        }

        HomePage homePage = new HomePage(driver);
        LoginPage loginPage = new LoginPage(driver);
        MyAccountPage accountPage = new MyAccountPage(driver);
        CategoryPage categoryPage = new CategoryPage(driver);
        CartPage cartPage = new CartPage(driver);

        [Test]
        [AllureSubSuite("Adding to cart")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("Account Page", "http://automationpractice.com/index.php?controller=authentication&back=my-account")]
        [AllureTest("Add to cart and check total")]
        [AllureOwner("Albina Mashlyakevich")]
        public void AddProduct_ToCart_AndCheckTotal_Test()
        {
            homePage.ClickSigninButton();
            loginPage.FillOutSigninForm();
            loginPage.SignIn();
            accountPage.ClickMenuItemLink();
            categoryPage.AddThreeItemsToCart();
            categoryPage.CheckAddedItems();
            categoryPage.OpenCartPage();
            cartPage.CheckTotalPrice();
        }
    }
}
