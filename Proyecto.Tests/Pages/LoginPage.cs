using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Tests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UserNameid => _driver.FindElement(By.Id("user-name"));

        private IWebElement Passwordid => _driver.FindElement(By.Id("password"));

        private IWebElement BtnLogin => _driver.FindElement(By.Id("login-button"));

        private IWebElement BtnMenu => _driver.FindElement(By.Id("react-burger-menu-btn"));


      

        private IWebElement Msgerror => _driver.FindElement(By.CssSelector("div.error-message-container h3"));


        public void ingresarLogin(string user, string password)
        {

            UserNameid.SendKeys(user);
            Passwordid.SendKeys(password);
        }
        public void ClickLogin()
        {
            BtnLogin.Click();
        }
        public void ClickMenu()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            BtnMenu.Click();
        }
        public void ClickLogout()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var btnlogout = wait.Until(drv =>
            {
                var element = drv.FindElement(By.Id("logout_sidebar_link"));
                return element.Displayed ? element : null;
            });

        }
        public string GetMessageIncorrectPassword()
        {
            if (Msgerror.Text == "Epic sadface: Sorry, this user has been locked out.")
            {
                return Msgerror.Text;
            }
            else {
                return Msgerror.Text;
            }
            
        }
    }
}
