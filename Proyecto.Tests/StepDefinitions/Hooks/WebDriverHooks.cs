using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Proyecto.Tests.Hooks
{
    [Binding]
    public class WebHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public WebHooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario("@Web")]
        public void BeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _scenarioContext["Driver"] = driver; // Compartimos el driver vía ScenarioContext
        }

        [AfterScenario("@Web")]
        public void AfterScenario()
        {
            var driver = (IWebDriver)_scenarioContext["Driver"];
            driver?.Quit();
        }
    }
}
