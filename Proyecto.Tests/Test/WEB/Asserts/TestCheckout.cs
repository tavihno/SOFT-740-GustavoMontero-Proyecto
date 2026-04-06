using OpenQA.Selenium.Support.UI;
using Proyecto.Tests.Pages;
using Proyecto.Tests.Test.WEB.Asserts;
using Proyecto.Tests.Utilities.Configuración;
using Proyecto.Tests.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Tests.Test.WEB.Asserts
{
    public class TestCheckout : TestBase
    {
        [Test, TestCaseSource(typeof(CheckoutDataSource), nameof(CheckoutDataSource.MessageInformation))]
        public void CheckoutWithValidInformation(string name, string lastname, string zip)
        {
            var loginPage = new LoginPage(Driver);
            loginPage.ingresarLogin("standard_user", "secret_sauce");
            loginPage.ClickLogin();
            var productPage = new ProductPage(Driver);
            productPage.AddProduct1ToCart();
            productPage.AddProduct2ToCart();
            productPage.ClickCart();
            productPage.ClickCheckout();
            var checkoutPage = new CheckoutPage(Driver);
            checkoutPage.FillCheckoutInformation(name, lastname, zip);
            checkoutPage.ClickContinue();
            checkoutPage.ClickFinish(); 
            Assert.That(checkoutPage.GetSuccessMessage, Is.EqualTo("Thank you for your order!"));
            checkoutPage.ClickBackHome();   

        }
    }
}
