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

        [Test]
        public void CheckoutWithInvalidInformationfirtname()
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
            checkoutPage.FillCheckoutInformation("", "Prueba", "12345");
            checkoutPage.ClickContinue();
            Assert.That(checkoutPage.GetErrorMessage, Is.EqualTo("Error: First Name is required"));
            ScreenshotHelper.TakeScreenshot(Driver, "errorfirtname.png");
        }
        [Test]
        public void CheckoutWithInvalidInformationlastname()
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
            checkoutPage.FillCheckoutInformation("prueba", "", "12345");
            checkoutPage.ClickContinue();
            Assert.That(checkoutPage.GetErrorMessage, Is.EqualTo("Error: Last Name is required"));
            ScreenshotHelper.TakeScreenshot(Driver, "errorlastname.png");
        }

        [Test]
        public void CheckoutWithInvalidInformationZip()
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
            checkoutPage.FillCheckoutInformation("prueba", "prueba", "");
            checkoutPage.ClickContinue();
            Assert.That(checkoutPage.GetErrorMessage, Is.EqualTo("Error: Postal Code is required"));
            ScreenshotHelper.TakeScreenshot(Driver, "errorzip.png");
        }
    }
    }
