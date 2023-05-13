using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using DemoKatalon.Registry;
using DemoKatalon.Utils;
using OpenQA.Selenium;
using DemoKatalon.Pages;

namespace DemoKatalon.StepDefinitions
{

    [Binding]
    public class CartStepDefinitions : BaseTest
    {
        [BeforeTestRun]
        public static void BeforeFeature()
        {
            extent.StartTest("Verify cart functionality page");
            LoadPage();
        }

        [Given(@"I add four random items to my cart")]
        public void GivenIAddFourRandomItemsToMyCart()
        {
            Pages.ShopPage.AddToCart();
        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            Pages.ShopPage.ViewCart();
        }

        [When(@"I search for lowest price item")]
        public void WhenISearchForLowestPriceItem()
        {
            Pages.CartPage.SearchForLowestPriceItem();
        }

        [When(@"I am able to remove the lowest price item from my cart")]
        public void WhenIAmAbleToRemoveTheLowestPriceItemFromMyCart()
        {
            Pages.CartPage.RemoveTheLowestPriceItem();
        }

        [Then(@"I find total (.*) items listed in my cart")]
        [Then(@"I am able to verify (.*) items in my cart")]
        public void ThenIAmAbleToVerifyItemsInMyCart(int count)
        {
            Pages.CartPage.VerifyItemsInCart(count);
        }

        [AfterFeature]
        public static void AfterFeature()
        {

            TearDown();

        }

    }
}
