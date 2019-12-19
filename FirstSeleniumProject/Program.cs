using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using FirstSeleniumProject.Pages;
using OpenQA.Selenium.Support.UI;
using FirstSeleniumProject.Helpers;

namespace FirstSeleniumProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.runfast.franklidev.com/Account/Login";
            string email = "jerry@franklidev.co.uk";
            string password = "jerry @franklidev.co.uk";
            string failedMessage = "Invalid username or password.";

            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl(url);

            //Maximize the window
            driver.Manage().Window.Maximize();

            //Prepare page
            LoginPage loginPage = new LoginPage(driver).SetEmail(email: email).SetPassword(password: password).SubmitForm();

            LoginFailedPage loginFailedPage = new LoginFailedPage(driver);
            if (By.CssSelector(loginFailedPage.ErrorInfoTagClass).WaitElement(driver, throwTimeoutException: false,
                logError: Console.WriteLine) != null)
            {
                //Check with the expecation
                Trace.Assert(loginFailedPage.LoginFailed(failedMessage), "Error: Failed on checking failure of log in");
            }

            //Close the browser
            driver.Close();
        }
    }
}
