using MeDirectNC.PageModels;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MeDirectNC.StepBindings
{
    [Binding]

    public class Login {
        LoginPage loginpage = new LoginPage();


        [Given(@"User navigates to login page")]
        public void NavigatesToLoginPage() {
            loginpage.NavigatesToLoginPage();
        }

        [When(@"User enters valid credentials '(.*)' and '(.*)'")]
        public void SetPasswordAndUsername(string username, string password) {
            loginpage.SetPasswordAndUsername(username, password);
        }

        [Then(@"User should be able to login")]
        public void CheckValidLogin() {
            loginpage.CheckValidLogin();
        }

        [Then(@"Browser is closed")]
        public void CloseBrowser() {
            loginpage.CloseBrowser();
        }

        [When(@"User enters invalid credentials '(.*)' and '(.*)'")]
        public void SetInvalidCredentials(string username, string password) {
            loginpage.SetPasswordAndUsername(username, password);
        }
        
        [Then(@"User should not be able to login")]
        public void CheckInvalidLogin() {
            loginpage.CheckInvalidLogin();
               
        }
                
        [Then(@"User should be able to see the item names are different from product details")]
        public void CheckItemsNamesWithFalseCondition() {
            loginpage.CheckItemsNamesWithFalseCondition();               
        }
        
        [Then(@"User should be able to see the items are same with product details")]
        public void CheckItemsNamesWithTrueCondition() {
            loginpage.CheckItemsNamesWithTrueCondition();               
        }
        
        [When(@"User add a product")]
        public void AddProduct() {
            loginpage.AddProduct();               
        
        }
        
        [Then(@"User should be able to purchase the product")]
        public void PurchaseProductSuccessfully() {
            loginpage.PurchaseProductSuccessfully();               
        }

    }
}