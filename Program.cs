using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main()
    {
        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Enter valid username
            driver.FindElement(By.Id("user-name"))
                  .SendKeys("standard_user");

            // Enter valid password
            driver.FindElement(By.Id("password"))
                  .SendKeys("secret_sauce");

            // Click Login
            driver.FindElement(By.Id("login-button"))
                  .Click();

            // Find Products page
            IWebElement productsTitle =
                driver.FindElement(By.ClassName("title"));

            // Verify Products page
            if (productsTitle.Displayed &&
                productsTitle.Text == "Products")
            {
                Console.WriteLine(
                    "TEST PASSED - Successful login opened the Products page!"
                );
            }
            else
            {
                Console.WriteLine(
                    "TEST FAILED - Products page was not displayed."
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                "TEST FAILED - " + ex.Message
            );
        }
        finally
        {
            driver.Quit();
        }
    }
}