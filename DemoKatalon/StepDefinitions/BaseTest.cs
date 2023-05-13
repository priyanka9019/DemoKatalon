using DemoKatalon.Registry;
using DemoKatalon.Utils;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKatalon.StepDefinitions
{
    public class BaseTest
    {
        protected static ExtentManager extent = new ExtentManager();
        protected static IWebDriver _driver = new ChromeDriver();
        protected readonly PageRegister Pages = new PageRegister(_driver, extent);
        private static readonly string baseUrl = "https://cms.demo.katalon.com/";
        protected static void LoadPage()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(baseUrl);
        }

        protected static void TearDown()
        {
            extent.ExtentEnd();
            _driver.Quit();
        }
    }
}
