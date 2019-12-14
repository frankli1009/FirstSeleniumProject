using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FirstSeleniumProject.Helpers
{
    public static class ByHelpers
    {
        public static IWebElement WaitElement(this By by, IWebDriver driver,
            int timeout = 10, bool throwTimeoutException = true,
            Action<string> logError = null)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (WebDriverTimeoutException)
            {
                if (logError != null)
                    logError("Timeout. Element with locator: " + by + " was not found in current context page.");
                if (throwTimeoutException) throw;
                else return null;
            }
            catch (Exception e)
            {
                if (logError != null)
                {
                    logError("Failed to find element with locator: " + by);
                    logError(e.Message);
                    logError(e.StackTrace);
                }
                if (throwTimeoutException) throw;
                else return null;
            }
        }
    }
}
