using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;

namespace FinalTask.AutomationResources
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();
                case BrowserType.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }
        public IWebDriver CreateChromeDriver()
        {
            var directoryWithChromeDriver = GetChromeBinaryLocationInAutomationResources();
            return new ChromeDriver(directoryWithChromeDriver);
        }

        public IWebDriver CreateFirefoxDriver()
        {
            var directoryWithFirefoxDriver = GetFirefoxBinaryLocationInAutomationResources();
            return new FirefoxDriver(directoryWithFirefoxDriver);
        }


        public IWebDriver CreateSauceDriver(string browser, string version, string os)
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Version, version);
            capabilities.SetCapability(CapabilityType.Platform, os);
            capabilities.SetCapability("name", TestContext.CurrentContext.Test.Name);
            capabilities.SetCapability("username", Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
            capabilities.SetCapability("accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
            return new RemoteWebDriver(new Uri("https://{sauceUsername}:{sauceAccessKey}@ondemand.eu-central-1.saucelabs.com:443/wd/hub"),
                capabilities, TimeSpan.FromSeconds(600));
        }


        public IWebDriver CreateSeleniumGridDriver()
        {
            string nodeURL = "http://localhost:4444/wd/hub";
            DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
            desiredCapabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            desiredCapabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.WinNT));
            desiredCapabilities.SetCapability(CapabilityType.BrowserName, "firefox");
            desiredCapabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.WinNT));
            return new RemoteWebDriver(new Uri(nodeURL), desiredCapabilities);
        }

        private string GetChromeBinaryLocationInAutomationResources()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.GetFullPath(Path.Combine(outPutDirectory, @"..\..\..\bin\Debug"));
        }

        private string GetFirefoxBinaryLocationInAutomationResources()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.GetFullPath(Path.Combine(outPutDirectory, @"..\..\..\bin\Debug"));
        }
    }
}

