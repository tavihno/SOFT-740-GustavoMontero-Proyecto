using Reqnroll;
using OpenQA.Selenium;
using Proyecto.Tests.Pages;
using Proyecto.Tests.Utilities.Helpers;
using NUnit.Framework;

namespace Proyecto.Tests.StepDefinitions
{
    [Binding]
    public class ProductSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _productPage;

        public ProductSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["Driver"];
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductPage(_driver);
        }

        [Given(@"que el usuario está en la página de inventario con ""(.*)"" y ""(.*)""")]
        public void GivenUsuarioLogueado(string user, string pass)
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _loginPage.ingresarLogin(user, pass);
            _loginPage.ClickLogin();
        }

        [When(@"el usuario agrega el Producto 1 y el Producto 2 al carrito")]
        [Given(@"que el usuario ha agregado el Producto 1 y el Producto 2 al carrito")]
        public void WhenAgregaProductos()
        {
            _productPage.AddProduct1ToCart();
            _productPage.AddProduct2ToCart();
        }

        [Then(@"el contador del carrito debería mostrar (.*)")]
        public void ThenElContadorDeberiaMostrar(int cantidadEsperada)
        {
            int actualCount = _productPage.GetCartCount();
            Assert.That(actualCount, Is.EqualTo(cantidadEsperada),
                $"Error: Se esperaba {cantidadEsperada} pero hay {actualCount}");
        }

        [When(@"navega a la página del carrito")]
        public void WhenNavegaAlCarrito()
        {
            _productPage.ClickCart();
        }

        [When(@"elimina el Producto 2")]
        public void WhenEliminaElProducto()
        {
            _productPage.RemoveProduct2FromCart();
        }

        [Then(@"se toma una captura de pantalla con el nombre ""(.*)""")]
        public void ThenTomarCaptura(string nombreImagen)
        {
            ScreenshotHelper.TakeScreenshot(_driver, $"{nombreImagen}.png");
        }
    }
}