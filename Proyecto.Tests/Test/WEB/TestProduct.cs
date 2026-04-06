using OpenQA.Selenium.Support.UI;
using Proyecto.Tests.Pages;
using Proyecto.Tests.Test.WEB.Asserts;
using Proyecto.Tests.Utilities.Configuración;
using Proyecto.Tests.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Proyecto.Tests.Test.WEB
{
    public class TestProduct : TestBase
    {
        [Test]
        public void AddProductsToCart()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.ingresarLogin("standard_user", "secret_sauce");
            loginPage.ClickLogin();
            var productPage = new ProductPage(Driver);
            productPage.AddProduct1ToCart();
            productPage.AddProduct2ToCart();
            int cartCount = productPage.GetCartCount();
            Assert.That(cartCount, Is.EqualTo(2), $"Se esperaba 2 productos en el carrito, pero se encontró {cartCount}.");
            ScreenshotHelper.TakeScreenshot(Driver, "Conteoproduncto.png");
        }
        [Test]
        public void RemoveProductFromCart()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.ingresarLogin("standard_user", "secret_sauce");
            loginPage.ClickLogin();
            var productPage = new ProductPage(Driver);
            productPage.AddProduct1ToCart();
            productPage.AddProduct2ToCart();
            productPage.ClickCart();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            productPage.RemoveProduct2FromCart();
            ScreenshotHelper.TakeScreenshot(Driver, "eliminarpriducto.png");
        }
    }
}
