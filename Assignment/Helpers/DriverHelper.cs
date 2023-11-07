using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Utils
{
    public class DriverHelper
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;

        // This will open web browser according to appsetings.json file browser value
        public void startBrowser(string browser, string url)
        {
            if (browser.Equals("Chrome"))
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);
                wait= wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }

            if (browser.Equals("FireFox"))
            {
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);
                wait = wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }

            if (browser.Equals("Microsoft Edge"))
            {
                driver = new EdgeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);
                wait = wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }
        }

        // This will close driver instance
        public void stopBrowser()
        {
            driver.Quit();
        }

        // This will click on web element
        public void click(By element)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element));
            driver.FindElement(element).Click();
        }

        // This will send text values into web element
        public void type(By element, string value, bool clear=true)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element));
            if (clear)
            {
                driver.FindElement(element).Clear();
                driver.FindElement(element).SendKeys(value);
            }
            else 
                driver.FindElement(element).SendKeys(value);
        }

        // This will get the text value of a web element
        public string getText(By element)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(element));
            return driver.FindElement(element).Text;
        }

        // This will return current page title
        public string getPageTitle()
        {
            return driver.Title;
        }

        // This will return current page url
        public string getPageUrl()
        {
            return driver.Url;
        }

    }
}
