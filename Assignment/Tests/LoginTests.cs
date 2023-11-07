using Assignment.Helpers;
using Assignment.Pages;
using Assignment.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Login test suite")]
    [AllureFeature("Login Feature")]
    public class LoginTests 
    {
        DriverHelper driverHelper;

        [SetUp]
        public void Setup()
        {
            driverHelper= new DriverHelper();
            driverHelper.startBrowser(ConfigurationHelper.browser, ConfigurationHelper.baseUrl);
        }

        [Test]
        public void VerifyErrorMessage_WhenUsernNameIsEmpty()
        {
            // Act
            LoginPage loginPage=new LoginPage();
            loginPage.fillPassword(ConfigurationHelper.password);
            Console.WriteLine("Successfully entered password");
            loginPage.login();
            Console.WriteLine("Successfully selected login button");
            // Assertion
            Assert.IsTrue(loginPage.getErrorLabelText().Contains("Username is required"));
        }

        [Test]
        public void VerifyErrorMessage_WhenPasswordIsEmpty()
        {
            // Act
            LoginPage loginPage = new LoginPage();
            loginPage.fillUserName(ConfigurationHelper.userName);
            Console.WriteLine("Successfully entered user name");
            loginPage.login();
            Console.WriteLine("Successfully selected login button");
            // Assertion
            Assert.IsTrue(loginPage.getErrorLabelText().Contains("Password is required"));
        }

        [Test]
        public void VerifyErrorMessage_ForInvalidCredentials()
        {
            // Act
            LoginPage loginPage = new LoginPage();
            loginPage.fillUserName("invalid");
            Console.WriteLine("Successfully entered incorrect user name");
            loginPage.fillPassword("invalid");
            Console.WriteLine("Successfully entered incorrect password");
            loginPage.login();
            Console.WriteLine("Successfully selected login button");
            // Assertion
            Assert.IsTrue(loginPage.getErrorLabelText().Contains("Username and password do not match any user in this service"));
        }

        [Test]
        public void VerifySuccessLogin()
        {
            // Act
            LoginPage loginPage = new LoginPage();
            loginPage.fillUserName(ConfigurationHelper.userName);
            Console.WriteLine("Successfully entered correct user name");
            loginPage.fillPassword(ConfigurationHelper.password);
            Console.WriteLine("Successfully entered correct password");
            loginPage.login();
            Console.WriteLine("Successfully selected login button");
            HomePage homePage= new HomePage();
            // Assertion
            Assert.IsTrue(homePage.getHeadingText().Contains("Swag Labs"));
            Assert.IsTrue(homePage.getPageUrl().Contains("inventory.html"));
        }

        [TearDown]
        public void TearDown()
        {
            driverHelper.stopBrowser();
        }
    }
}
