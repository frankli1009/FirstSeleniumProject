using System;
using OpenQA.Selenium;

namespace FirstSeleniumProject.Pages
{
    public class LoginPage
    {
        public LoginPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        //Web driver
        protected IWebDriver _driver;

        //CSS selection / XPath
        protected string _emailId = "Email";
        protected string _passwordName = "Password";
        protected string _loginButtonTagValue = "input[value='Log in']";

        protected string _emailPath = "//*[@id='Email']";
        protected string _passwordPath = "//*[@name='Password']";
        protected string _loginButtonPath = "//*[@value='Log in']";

        //Methods
        public LoginPage SetEmail(string email)
        {
            //Find the Email text box using Id
            IWebElement emailElement = _driver.FindElement(By.Id(_emailId));
            //Find the Email text box using xpath
            //IWebElement emailElement = _driver.FindElement(By.XPath(_emailPath));
            //Enter some text in search text box
            emailElement.SendKeys(email);

            return this;
        }

        public LoginPage SetPassword(string password)
        {
            //Find the Password text box using Name
            IWebElement passwordElement = _driver.FindElement(By.Name(_passwordName));
            //Find the Password text box using xpath
            //IWebElement passwordElement = _driver.FindElement(By.XPath(_passwordPath));
            //Enter some text in search text box
            passwordElement.SendKeys(password);

            return this;
        }

        public LoginPage SubmitForm()
        {
            //Find the Log in button by Tag and Valuie
            IWebElement login_button = _driver.FindElement(By.CssSelector(_loginButtonTagValue));
            //Find the Log in button using xpath
            //IWebElement login_button = _driver.FindElement(By.XPath(_loginButtonPath));
            //Submit the form
            login_button.Click();

            return this;
        }

    }
}
