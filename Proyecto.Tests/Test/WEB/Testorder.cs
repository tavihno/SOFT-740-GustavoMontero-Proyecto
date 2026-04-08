using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Proyecto.Tests.Pages;
using Proyecto.Tests.Utilities.Configuración;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Tests.Test.WEB
{
   public class Testorder : TestBase
    {
        [Test]
        public  void orderza() {
            var loginPage = new LoginPage(Driver);
            loginPage.ingresarLogin("standard_user", "secret_sauce");
            loginPage.ClickLogin();
            var Orderpage = new Orderpage(Driver);
            Orderpage.SeleccionarZA();
            var firstItem = Orderpage.GetFirstProductName();

            Assert.That(firstItem, Is.EqualTo("Test.allTheThings() T-Shirt (Red)"),
                $"El primer artículo mostrado fue distinto: {firstItem}");

        }
        [Test]
        public void orderaz()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.ingresarLogin("standard_user", "secret_sauce");
            loginPage.ClickLogin();
            var Orderpage = new Orderpage(Driver);
            Orderpage.SeleccionarAZ();
            var firstItem = Orderpage.GetFirstProductName();

            Assert.That(firstItem, Is.EqualTo("Sauce Labs Backpack"),
                $"El primer artículo mostrado fue distinto: {firstItem}");

        }
        [Test]
        public void orderpricelow()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.ingresarLogin("standard_user", "secret_sauce");
            loginPage.ClickLogin();
            var Orderpage = new Orderpage(Driver);
            Orderpage.SeleccionarLOW();
            var firstItem = Orderpage.GetFirstProductName();

            Assert.That(firstItem, Is.EqualTo("Sauce Labs Onesie"),
                $"El primer artículo mostrado fue distinto: {firstItem}");

        }
        [Test]
        public void orderpricehigh()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.ingresarLogin("standard_user", "secret_sauce");
            loginPage.ClickLogin();
            var Orderpage = new Orderpage(Driver);
            Orderpage.SeleccionarHigh();
            var firstItem = Orderpage.GetFirstProductName();

            Assert.That(firstItem, Is.EqualTo("Sauce Labs Fleece Jacket"),
                $"El primer artículo mostrado fue distinto: {firstItem}");

        }
    }
}
