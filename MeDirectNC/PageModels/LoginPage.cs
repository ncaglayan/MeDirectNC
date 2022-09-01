using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MeDirectNC.PageModels
{
    public class LoginPage : IDisposable
    {
        private ChromeDriver driver;
        public LoginPage() => driver = new ChromeDriver();

        public void NavigatesToLoginPage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            System.Threading.Thread.Sleep(2000);
        }
        public void SetPasswordAndUsername(string username, string password)
        {
            var userName = driver.FindElement(By.Id("user-name"));
            userName.SendKeys(username);
            var passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys(password);
            var loginButton = driver.FindElement(By.Id("login-button"));
            loginButton.Click();
        }
        public void CheckValidLogin()
        {
            string title = driver.Title;
            Console.WriteLine(title);
            Assert.True(driver.Title.ToLower().Replace(" ", "").Contains("swaglabs"));
        }
        public void CloseBrowser()
        {
            driver.Close();
        }

        public void CheckInvalidLogin()
        {
            var errorMessage = "Epic sadface: Sorry, this user has been locked out.";
            var actualMessage = driver.FindElement(By.XPath("//div[@class='error-message-container error']")).Text;
            Console.WriteLine(actualMessage);
            Assert.True(actualMessage.Equals(errorMessage));
        }
        public void CheckItemsNamesWithFalseCondition()
        {
            ReadOnlyCollection<IWebElement> displayedOptions = driver.FindElements(By.XPath("//div[@class='inventory_item_name']"));
                for (int i = 0; i < displayedOptions.Count; i++)
                {
                    driver.SwitchTo().DefaultContent();
                    var option = driver.FindElement(By.XPath("(//div[@class='inventory_item_name'])["+(i+1)+"]"));
                    if (option.Displayed)
                    {
                        var firstProductTitle = option.Text;
                        option.Click();
                        System.Threading.Thread.Sleep(1000);
                        var ActualProductTitle = driver.FindElement(By.XPath("//div[@class='inventory_details_name large_size']"));
                        Assert.False(firstProductTitle.Equals(ActualProductTitle.Text));
                        driver.Navigate().Back();
                        System.Threading.Thread.Sleep(2000);
                }
    }  
}
        public void CheckItemsNamesWithTrueCondition()
        {
            ReadOnlyCollection<IWebElement> displayedOptions = driver.FindElements(By.XPath("//div[@class='inventory_item_name']"));
                for (int i = 0; i < displayedOptions.Count; i++)
                {
                    driver.SwitchTo().DefaultContent();
                    var option = driver.FindElement(By.XPath("(//div[@class='inventory_item_name'])["+(i+1)+"]"));
                    if (option.Displayed)
                    {
                        var firstProductTitle = option.Text;
                        option.Click();
                        System.Threading.Thread.Sleep(1000);
                        var ActualProductTitle = driver.FindElement(By.XPath("//div[@class='inventory_details_name large_size']"));
                        Assert.True(firstProductTitle.Equals(ActualProductTitle.Text));
                        driver.Navigate().Back();
                        System.Threading.Thread.Sleep(2000);
                }
    }  
}
        public void AddProduct()
        {
            var product = driver.FindElement(By.XPath("(//div[@class='inventory_item_name'])[2]"));
            product.Click();
            var addToCart = driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
            addToCart.Click();

        }

        public void PurchaseProductSuccessfully()
        {
            var shoppingBadge = driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']"));
            shoppingBadge.Click();
            var checkout = driver.FindElement(By.Id("checkout"));
            checkout.Click();
            var firstName= driver.FindElement(By.Id("first-name"));
            firstName.SendKeys("Nuri");
            var lastName= driver.FindElement(By.Id("last-name"));
            lastName.SendKeys("Caglayan");
            var zipCode= driver.FindElement(By.Id("postal-code"));
            zipCode.SendKeys("06720");
            var continuePurchase = driver.FindElement(By.Id("continue"));
            continuePurchase.Click();
            var finishTransaction= driver.FindElement(By.Id("finish"));
            finishTransaction.Click();
            var completePurchase = driver.FindElement(By.XPath("//h2[@class='complete-header']"));
            Assert.True(completePurchase.Text.Equals("THANK YOU FOR YOUR ORDER"));

        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }

    }
}
