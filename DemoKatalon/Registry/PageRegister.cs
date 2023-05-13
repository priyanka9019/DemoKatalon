using DemoKatalon.Utils;
using OpenQA.Selenium;
using DemoKatalon.Pages;

namespace DemoKatalon.Registry
{
    public class PageRegister
    {
        public ShopPage ShopPage { get; }
        public CartPage CartPage { get; }
        public PageRegister(IWebDriver driver, ExtentManager extent)
        {
            ShopPage = new ShopPage(driver, extent);
            CartPage = new CartPage(driver, extent);
        }
    }
}
