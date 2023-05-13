using DemoKatalon.Utils;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DemoKatalon.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        private readonly ExtentManager _extent;
    
        protected BasePage(IWebDriver driver, ExtentManager extent)
        {
            _driver = driver;
            _extent = extent;
        }
        protected void WaitUntilElementClickable(By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw ex;
            }
        }
        protected void WaitUntilElementIsVisible(By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw ex;
            }
        }

        protected IWebElement GetElement(By by)
        {
            WaitUntilElementIsVisible(by);
            try
            {
                return _driver.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {
                throw ex;
            }
        }

        protected IList<IWebElement> GetElements(By by)
        {
            try
            {
                return _driver.FindElements(by);
            }
            catch (NoSuchElementException ex)
            {
                throw ex;
            }
        }
      
       
        protected void ScrollToElementClick(By by)
        {
            IWebElement target = _driver.FindElement(by);
            // Scroll to the element using JavaScriptExecutor
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", target);

            // Perform the click action on the element
            Actions actions = new Actions(_driver);
            actions.MoveToElement(target).Click().Perform();
        }
      
        protected string GetText(By by)
        {
            try
            {
                return GetElement(by).Text;
            }
            catch (ElementNotVisibleException ex)
            {
                throw ex;
            }
        }
       

        protected void PageRefresh()
        {
            _driver.Navigate().Refresh();
        }
    }
}
