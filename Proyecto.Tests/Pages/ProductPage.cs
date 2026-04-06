using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Tests.Pages
{

    public class ProductPage
    {
        private readonly IWebDriver _driver;
        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Product1 => _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement Product2 => _driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
        private IWebElement BTNcarrito => _driver.FindElement(By.CssSelector("a.shopping_cart_link"));

        private IWebElement Contadorbtn => _driver.FindElement(By.CssSelector("span.shopping_cart_badge"));

        private IWebElement btncheout => _driver.FindElement(By.Id("checkout"));


        public int GetCartCount()
        {
            try
            {
                var badge = Contadorbtn;
                return int.Parse(badge.Text);
            }
            catch (NoSuchElementException)
            {
                // Si no existe el badge, significa que el carrito está vacío
                return 0;
            }
        }

        public void AddProduct1ToCart()
        {
            Product1.Click();
        }
        public void AddProduct2ToCart()
        {
            Product2.Click();
        }

        public void ClickCart()
        {
            BTNcarrito.Click();
        }
        public void RemoveProduct2FromCart()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var removeBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("remove-sauce-labs-onesie")));
            removeBtn.Click();

        }
        public void ClickCheckout()
        {
            
            btncheout.Click();
        }



        }
}