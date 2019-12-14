using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace FirstSeleniumProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "jerry@franklidev.co.uk";
            string password = "jerry @franklidev.co.uk";
            string failedMessage = "Invalid username or password.";

            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("http://www.runfast.franklidev.com/Account/Login");

            //Maximize the window
            driver.Manage().Window.Maximize();

            //Prepare page
            LoginPage loginPage = new LoginPage(driver).SetEmail(email: email).SetPassword(password: password).SubmitForm();

            //Check with the expecation
            Debug.Assert(loginPage.LoginFailed(failedMessage), "Error: Failed on checking failure of log in");

            //Close the browser
            driver.Close();
        }
    }
}
