using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpNetCore.Pages;


namespace SeleniumCSharpNetCore
{
    public class Tests: DriverHelper
    {
 
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setup");
            Driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com/");

            Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");

            CustomControl control = new CustomControl();
            CustomControl.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Mango");

            Console.WriteLine("Test 1");
            Assert.Pass();
        }
        
        [Test]
        public void LoginTest()
        {
            Driver.Navigate().GoToUrl("http://localhost:64429/");

            HomePage homePage = new HomePage();
            LoginPage loginPage = new LoginPage();
            
            homePage.ClickLogin();
            loginPage.EnterUserNameAndPassword("admin", "password");
            loginPage.ClickLogin();
            
            Assert.AreEqual(homePage.IsLogOffExist, true);
        }
    }
}