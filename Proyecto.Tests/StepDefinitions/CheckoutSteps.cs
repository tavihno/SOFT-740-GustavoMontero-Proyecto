using Reqnroll;
using OpenQA.Selenium;
using Proyecto.Tests.Pages;
using Proyecto.Tests.Utilities.Helpers;
using NUnit.Framework;

namespace Proyecto.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _productPage;
        private readonly CheckoutPage _checkoutPage;

        public CheckoutSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["Driver"];
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
        }

        [Given(@"que el usuario está logueado y tiene productos en el carrito")]
        public void GivenUsuarioLogueadoConProductos()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _loginPage.ingresarLogin("standard_user", "secret_sauce");
            _loginPage.ClickLogin();

            _productPage.AddProduct1ToCart();
            _productPage.AddProduct2ToCart();
            _productPage.ClickCart();
            _productPage.ClickCheckout();
        }

        [When(@"ingresa la información de envío con ""(.*)"", ""(.*)"" y ""(.*)""")]
        public void WhenIngresaInformacion(string name, string lastname, string zip)
        {
            _checkoutPage.FillCheckoutInformation(name, lastname, zip);
        }

        [When(@"intenta continuar con el siguiente paso")]
        public void WhenContinua()
        {
            _checkoutPage.ClickContinue();
        }

        [When(@"finaliza la compra")]
        public void WhenFinalizaCompra()
        {
            _checkoutPage.ClickContinue();
            _checkoutPage.ClickFinish();
        }

        [Then(@"se debe mostrar el mensaje de éxito ""(.*)""")]
        public void ThenMensajeExito(string mensajeEsperado)
        {
            Assert.That(_checkoutPage.GetSuccessMessage(), Is.EqualTo(mensajeEsperado));
            _checkoutPage.ClickBackHome();
        }

        [Then(@"se debe mostrar el mensaje de error ""(.*)""")]
        public void ThenMensajeError(string mensajeEsperado)
        {
            Assert.That(_checkoutPage.GetErrorMessage(), Is.EqualTo(mensajeEsperado));
        }

        [Then(@"se toma una captura de error con nombre ""(.*)""")]
        public void ThenCapturaError(string nombreFoto)
        {
            ScreenshotHelper.TakeScreenshot(_driver, $"{nombreFoto}.png");
        }
    }
}