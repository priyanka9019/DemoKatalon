using DemoKatalon.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKatalon.Pages
{
    public class CartPage : BasePage
    {
        private readonly ExtentManager _extent;
        public CartPage(IWebDriver driver, ExtentManager extent) : base(driver, extent)
        {
            _extent = extent;
        }
        private readonly By itemsTable = By.XPath("//table[contains(@class,'woocommerce-cart-form__contents')]");
        private readonly By cartItems = By.CssSelector("tbody > tr.woocommerce-cart-form__cart-item");
        private readonly By removeLink = By.CssSelector(".product-remove a");
        private readonly By msgAlert = By.CssSelector("div.woocommerce-message");
        IWebElement lowestPricedItem = null;
        IList<IWebElement> lstCartItems = null;

        public void SearchForLowestPriceItem()
        {

            decimal lowestPrice = decimal.MaxValue;

            foreach (IWebElement cartItem in lstCartItems)
            {
                IWebElement priceElement = cartItem.FindElement(By.ClassName("product-price"));
                // Remove the currency symbol
                string priceText = priceElement.Text.Trim().Replace("$", "");
                decimal price = decimal.Parse(priceText);

                if (price < lowestPrice)
                {
                    lowestPrice = price;
                    lowestPricedItem = cartItem;
                }
            }

        }

        public void RemoveTheLowestPriceItem()
        {
            try
            {
                if (lowestPricedItem != null)
                {
                    //remove lowest priced item
                    WaitUntilElementIsVisible(removeLink);
                    IWebElement nameElement = lowestPricedItem.FindElement(removeLink);
                    nameElement.Click();
                    Assert.IsTrue(GetText(msgAlert).Contains("removed"), "Alert message doesn't verified!");
                    _extent.Info("Removed the lowest price item from Cart");
                }
            }
            catch
            {
                _extent.TestFail("Verification failed! Item has not removed");
                Assert.Fail();
                throw;
            }

        }

        public void VerifyItemsInCart(int count)
        {
            try
            {
                Thread.Sleep(3000);
                PageRefresh();
                lstCartItems = GetElement(itemsTable).FindElements(cartItems);
                Assert.AreEqual(count, lstCartItems.Count(), $"Expected {count} items in the cart, but found {lstCartItems.Count()} items.");
                _extent.Info($"Verified {lstCartItems.Count()} items in the cart. Expected: {count}, Actual: {lstCartItems.Count()}");
                _extent.TestPass("Verify correct number of items in cart!");
            }
            catch
            {
                _extent.Info($"Verified {lstCartItems.Count()} items in the cart. Expected: {count}, Actual: {lstCartItems.Count()}");
                _extent.TestFail("Incorrect number of items in cart!");
                Assert.Fail();
                throw;
            }
        }
    }
}
