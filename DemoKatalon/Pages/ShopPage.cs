using DemoKatalon.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKatalon.Pages
{
    public class ShopPage : BasePage
    {
        private readonly ExtentManager _extent;
        public ShopPage(IWebDriver driver, ExtentManager extent) : base(driver, extent)
        {
            _extent = extent;
        }
        private readonly By btnSearch = By.XPath("//a[@class='button product_type_simple add_to_cart_button ajax_add_to_cart']");
        private readonly By cartMenu = By.XPath("//div[@class='menu']//a[text()='Cart']");

        public void AddToCart()
        {
            // Find all the "Add to cart" buttons
            IList<IWebElement> addToCartButtons = GetElements(btnSearch);

            // Generate four random numbers

            Random random = new Random();
            List<int> randomIndices = new List<int>();

            while (randomIndices.Count < 4)
            {
                int randomIndex = random.Next(1, addToCartButtons.Count);
                if (!randomIndices.Contains(randomIndex))
                {
                    randomIndices.Add(randomIndex);
                }

            }
            // Arrange in ascending order to avoild scroll to the element
            randomIndices.Sort((x, y) => x.CompareTo(y));

            // Click on the "Add to cart" buttons
            foreach (int index in randomIndices)
            {
                addToCartButtons[index].Click();
            }

        }
        public void ViewCart()
        {
            ScrollToElementClick(cartMenu);
        }
    }
}
