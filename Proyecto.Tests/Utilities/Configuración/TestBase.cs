using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Proyecto.Tests.Reporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Tests.Utilities.Configuración
{
 
        public abstract class TestBase : ReportedTestBase
        {
            protected IWebDriver Driver;

            [SetUp]
            public void SetupDriver()
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                options.AddArgument("--disable-notifications");
                options.AddArgument("--disable-infobars");
                options.AddArgument("--window-size=1920,1080");
                options.AddArgument("--headless=new");
                Driver = new ChromeDriver(options);

                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Driver.Navigate().GoToUrl("https://www.saucedemo.com/");

                // Log inicial en el reporte
                LogInfo("Driver inicializado y página cargada.");
            }

            [TearDown]
            public void TearDownDriver()
            {
                if (Driver != null)
                {
                    Driver.Quit();
                    Driver.Dispose();
                    LogInfo("Driver cerrado correctamente.");
                }
            }
        }

    }
