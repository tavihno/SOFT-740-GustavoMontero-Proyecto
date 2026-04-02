using OpenQA.Selenium.Support.UI;
using Proyecto.Tests.Pages;
using Proyecto.Tests.Test.WEB.Asserts;
using Proyecto.Tests.Utilities.Configuración;
using Proyecto.Tests.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Tests.Test.WEB
{
    public class TestLogin : TestBase
    {

        [Test, TestCaseSource(typeof(LoginDataSource), nameof(LoginDataSource.UsersIsValid))]
        public void LoginWithValidUser(string user, string password)
        {
            var loginPage = new LoginPage(Driver);
            loginPage.ingresarLogin(user, password);
            loginPage.ClickLogin();
            loginPage.ClickMenu();
            loginPage.ClickLogout();
            ScreenshotHelper.TakeScreenshot(Driver, $"LoginSuccess_{user}.png");
        }
        [Test, TestCaseSource(typeof(LoginDataSource), nameof(LoginDataSource.UsersNotValid))]
        public void LoginWithInvalidUser(string user, string password)
        {
            var loginPage = new LoginPage(Driver);
            loginPage.ingresarLogin(user, password);
            loginPage.ClickLogin();
            var errorMessage = loginPage.GetMessageIncorrectPassword();
            Assert.That(errorMessage, Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
            ScreenshotHelper.TakeScreenshot(Driver, $"LoginFailed_{user}.png");
        }
    }
}
