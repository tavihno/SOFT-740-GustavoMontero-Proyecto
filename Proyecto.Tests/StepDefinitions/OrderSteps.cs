using Reqnroll;
using OpenQA.Selenium;
using Proyecto.Tests.Pages;
using NUnit.Framework;

namespace Proyecto.Tests.StepDefinitions
{
    [Binding]
    public class OrderSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly Orderpage _orderPage;

        public OrderSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["Driver"];
            _loginPage = new LoginPage(_driver);
            _orderPage = new Orderpage(_driver);
        }

        [Given(@"que el usuario está autenticado en la página de inventario")]
        public void GivenUsuarioAutenticado()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _loginPage.ingresarLogin("standard_user", "secret_sauce");
            _loginPage.ClickLogin();
        }

        [When(@"selecciona la opción de ordenamiento ""(.*)""")]
        public void WhenSeleccionaOpcion(string filtro)
        {
            // Mapeo dinámico según el texto del Gherkin
            switch (filtro)
            {
                case "Name (Z to A)": _orderPage.SeleccionarZA(); break;
                case "Name (A to Z)": _orderPage.SeleccionarAZ(); break;
                case "Price (low to high)": _orderPage.SeleccionarLOW(); break;
                case "Price (high to low)": _orderPage.SeleccionarHigh(); break;
                default: throw new PendingStepException($"Filtro no soportado: {filtro}");
            }
        }

        [Then(@"el primer producto mostrado debe ser ""(.*)""")]
        public void ThenElPrimerProductoDebeSer(string productoEsperado)
        {
            string actualProduct = _orderPage.GetFirstProductName();
            Assert.That(actualProduct, Is.EqualTo(productoEsperado),
                $"El ordenamiento falló. Se esperaba {productoEsperado} pero se encontró {actualProduct}");
        }
    }
}