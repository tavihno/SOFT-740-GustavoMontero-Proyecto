using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Tests.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;
        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement Firstname => _driver.FindElement(By.Id("first-name"));
        private IWebElement lasttname => _driver.FindElement(By.Id("last-name"));
        private IWebElement Zipcode => _driver.FindElement(By.Id("postal-code"));
        private IWebElement btncontinue => _driver.FindElement(By.Id("continue"));
        private IWebElement btnFinish => _driver.FindElement(By.Id("finish"));
        private IWebElement msgsuccess => _driver.FindElement(By.CssSelector("h2.complete-header"));

        private IWebElement btnBackHome => _driver.FindElement(By.Id("back-to-products"));


        private IWebElement MSGERROR => _driver.FindElement(By.CssSelector("h3[data-test='error']"));




        public void FillCheckoutInformation(string firstName, string lastName, string zipCode)
        {
            Firstname.SendKeys(firstName);
            lasttname.SendKeys(lastName);
            Zipcode.SendKeys(zipCode);
        }
        public void ClickContinue()
        {
            btncontinue.Click();
        }
        public void ClickFinish()
        {
            btnFinish.Click();
        }
        public string GetSuccessMessage()
        {
            return msgsuccess.Text;
        }
        public void ClickBackHome()
        {
            btnBackHome.Click();

        }
        public string GetErrorMessage()
        {
            return MSGERROR.Text;


        }
    }
}
