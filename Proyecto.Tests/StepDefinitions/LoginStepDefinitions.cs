using Reqnroll;
using OpenQA.Selenium;
using Proyecto.Tests.Pages;
using NUnit.Framework;

namespace Proyecto.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly Orderpage _inventoryPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["Driver"];
            _loginPage = new LoginPage(_driver);
            _inventoryPage = new Orderpage(_driver);
        }

        [Given(@"que el usuario navega a la pagina de login")]
        public void GivenQueElUsuarioNavegaALaPaginaDeLogin()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"ingresa el usuario ""(.*)"" y la contraseña ""(.*)""")]
        public void WhenIngresaElUsuarioYLaContrasena(string user, string pass)
        {
            _loginPage.ingresarLogin(user, pass);
        }

        [When(@"hace clic en el boton de login")]
        public void WhenHaceClicEnElBotonDeLogin()
        {
            _loginPage.ClickLogin();
        }

        [Then(@"se debe validar el resultado para el usuario ""(.*)""")]
        public void ThenValidarResultado(string user)
        {
            if (user == "standard_user")
            {
                Assert.IsTrue(_driver.Url.Contains("inventory.html"));
            }
            else
            {
                var error = _loginPage.GetMessageIncorrectPassword();
                Assert.That(error, Does.Contain("Epic sadface"));
            }
        }

    }
}