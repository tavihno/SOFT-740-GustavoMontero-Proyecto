using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Tests.Pages
{
    public class Orderpage
    {
        private readonly IWebDriver _driver;

        public Orderpage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement dropDownElement => _driver.FindElement(By.ClassName("product_sort_container"));

        public void SeleccionarZA()
        {
            SelectElement select = new SelectElement(dropDownElement);
            select.SelectByText("Name (Z to A)");
        }
        public void SeleccionarAZ()
        {
            SelectElement select = new SelectElement(dropDownElement);
            select.SelectByText("Name (A to Z)");
        }
        public void SeleccionarLOW()
        {
            SelectElement select = new SelectElement(dropDownElement);
            select.SelectByText("Price (low to high)");
        }
        public void SeleccionarHigh()
        {
            SelectElement select = new SelectElement(dropDownElement);
            select.SelectByText("Price (high to low)");
        }


        public string GetFirstProductName()
        {
            return _driver.FindElement(By.CssSelector(".inventory_item_name")).Text;
        }
    

    }
}


    
