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

    public class WishlistTests : BaseTest
    {
        public WishlistTests(string browser, string version, string os) : base(browser, version, os)
        {
        }

        HomePage homePage = new HomePage(driver);
        LoginPage loginPage = new LoginPage(driver);
        MyAccountPage accountPage = new MyAccountPage(driver);
        MyWishlistsPage wishlistsPage = new MyWishlistsPage(driver);
        ProductPage productPage = new ProductPage(driver);

        [Test]
        [AllureSubSuite("Create wishlist")]
        [AllureSeverity(SeverityLevel.Normal)]
        [AllureLink("My Account", "http://automationpractice.com/index.php?controller=authentication&back=my-account")]
        [AllureTest("Test automated creation of Wishlist")]
        [AllureOwner("Albina Mashlyakevich")]
        public void NewWishlist_Created_Automatically_Test()
        {
            homePage.Open();
            homePage.ClickSigninButton();
            loginPage.FillOutSigninForm();
            loginPage.SignIn();
            accountPage.ClickMyWishlistsLink();
            wishlistsPage.CheckWishlistEmpty();
            wishlistsPage.ClickProductLink();
            productPage.ClickAddToWishlist();

            //Go back to wishlist page
            driver.Navigate().Back();
            driver.Navigate().Refresh();

            wishlistsPage.CheckWishlistCreatedAutomatically();
            wishlistsPage.DeleteCraetedWishlist();
        }

        [Test]
        [AllureSubSuite("Create wishlist")]
        [AllureSeverity(SeverityLevel.Normal)]
        [AllureLink("My Account", "http://automationpractice.com/index.php?controller=authentication&back=my-account")]
        [AllureTest("Test manual creation of Wishlist")]
        [AllureOwner("Albina Mashlyakevich")]
        public void NewWishlist_Created_Manually_Test()
        {
            homePage.Open();
            homePage.ClickSigninButton();
            loginPage.FillOutSigninForm();
            loginPage.SignIn();
            accountPage.ClickMyWishlistsLink();
            wishlistsPage.CreateNewWishlistManually();
            wishlistsPage.VerifyWishlistCreatedManually();
            wishlistsPage.ClickProductLink();
            productPage.ClickAddToWishlist();

            //Go back to wishlist page
            driver.Navigate().Back();
            driver.Navigate().Refresh();

            wishlistsPage.CheckQuantityOfProductsAdded(1);
        }
    }

}
