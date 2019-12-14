using System;
using OpenQA.Selenium;

namespace FirstSeleniumProject
{
    public class LoginPage
    {
        public LoginPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        //Web driver
        private IWebDriver _driver;

        //CSS selection / XPath
        private string _emailId = "Email";
        private string _passwordName = "Password";
        private string _loginButtonTagValue = "input[value='Log in']";
        private string _errorInfoTagClass = "div.validation-summary-errors ul li";

        private string _emailPath = "//*[@id='Email']";
        private string _passwordPath = "//*[@name='Password']";
        private string _loginButtonPath = "//*[@value='Log in']";
        private string _errorInfoPath = "//div[contains(@class, 'validation-summary-errors')]/ul/li";

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

        public bool LoginFailed(string failedMessage)
        {
            //Find error info by Tag and Class and child mode
            IWebElement error_li = _driver.FindElement(By.CssSelector(_errorInfoTagClass));
            //Find error info by XPath
            //IWebElement error_li = _driver.FindElement(By.XPath(_errorInfoPath));
            string error_text = error_li.Text;
            return error_text.StartsWith(failedMessage, StringComparison.CurrentCulture);
        }
    }
}
