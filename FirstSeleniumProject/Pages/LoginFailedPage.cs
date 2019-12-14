using System;
using OpenQA.Selenium;

namespace FirstSeleniumProject.Pages
{
    public class LoginFailedPage : LoginPage
    {
        protected string _errorInfoTagClass = "div.validation-summary-errors ul li";
        protected string _errorInfoPath = "//div[contains(@class, 'validation-summary-errors')]/ul/li";

        public LoginFailedPage(IWebDriver driver) :
            base(driver)
        {
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

        public string ErrorInfoTagClass => _errorInfoTagClass;
    }
}
