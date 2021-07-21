using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using Allure.NUnit.Attributes;


namespace FinalTask.Pages
{
    class LoginPage : BasePage
    {
        private string url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private string expectedPageTitle = "Login - My Store";
        private string firstName = "Test";
        private string lastName = "Test";
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "email_create")]
        public IWebElement NotRegisteredEmailField
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement RegisteredEmailField
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        public IWebElement CreateAccountButton
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "submitAccount")]
        public IWebElement RegisterButton
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement PasswordField
        {
            get; set;
        }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement SignInButton
        {
            get; set;
        }

        [AllureStep("Try to open login page")]
        public void Open()
        {
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists((By.TagName("title"))));
            Assert.AreEqual(expectedPageTitle, driver.Title, "Error cause Login page is not opened");
        }

        [AllureStep("Enter unique email address")]
        public void EnterEmailAddress()
        {
            Random randNum = new Random();

            int num = randNum.Next();

            string emailCode = num.ToString();

            string emailAddress = $"albinamashlyakevich+{emailCode}@gmail.com";

            NotRegisteredEmailField.SendKeys(emailAddress);

            Assert.AreEqual(emailAddress, NotRegisteredEmailField.Text);
        }

        [AllureStep("Try to create account")]
        public void ClickCreateAccountButton()
        {
            CreateAccountButton.Click();

            IWebElement subsectionTitle = driver.FindElement(By.XPath("//*[text() = 'Your personal information']"));
            Assert.True(subsectionTitle.Displayed, "Seems new account form fields are not displayed");
        }

        [AllureStep("Fill out required fields on new account form")]
        public void FillOutNewAccountlInfo()
        {
            //Your personal information
            driver.FindElement(By.Id("customer_firstname")).SendKeys(firstName);
            driver.FindElement(By.Id("customer_lastname")).SendKeys(lastName);
            driver.FindElement(By.Id("passwd")).SendKeys("12345");

            //Your Address
            driver.FindElement(By.Id("address1")).SendKeys("Broadway, 26");
            driver.FindElement(By.Id("city")).SendKeys("New York");
            SelectElement state = new SelectElement(driver.FindElement(By.Id("id_state")));
            state.SelectByValue("1");
            driver.FindElement(By.Id("postcode")).SendKeys("08410");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("89098776567");
        }

        [AllureStep("Try to submit new account form")]
        public MyAccountPage SubmitRegistrationForm()
        {
            RegisterButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return new MyAccountPage(driver);
        }

        [AllureStep("Check new account is created")]
        public void VerifyNewAccountCreated()
        {
            IWebElement actualAccountInfo = driver.FindElement(By.CssSelector("a.account>span"));
            string expectedUserinfo = firstName + " " + lastName;
            Assert.AreEqual(expectedUserinfo, actualAccountInfo.Text, "Actual account info does not correspont to expected");
        }

        [AllureStep("Fill out signin form")]
        public void FillOutSigninForm()
        {
            RegisteredEmailField.SendKeys("albinamashlyakevich+1@gmail.com");
            PasswordField.SendKeys("123456");
        }

        [AllureStep("Try to signin")]
        public MyAccountPage SignIn()
        {
            SignInButton.Click();

            return new MyAccountPage(driver);
        }

        [AllureStep("Check that user is signed in")]
        public void VerifyUserSignedIn()
        {
            IWebElement actualAccountInfo = driver.FindElement(By.CssSelector("a.account>span"));
            string expectedUserinfo = firstName + " " + lastName;
            Assert.AreEqual(expectedUserinfo, actualAccountInfo.Text, "Actual account info does not correspont to expected");
        }
    }
}