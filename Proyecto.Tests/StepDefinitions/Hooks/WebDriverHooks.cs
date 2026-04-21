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

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--headless=new");
            IWebDriver driver = new ChromeDriver(options);
            
            
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
