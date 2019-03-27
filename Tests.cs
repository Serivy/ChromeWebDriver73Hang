using OpenQA.Selenium.Chrome;
using System;

namespace WebDriverTest
{
    public class Tests
    {
        [NUnit.Framework.Test]
        public void RunTest()
        {
            using (var driver = new ChromeDriver())
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                    driver.Navigate().GoToUrl("http://www.google.com");
                }
                catch (Exception e)
                {
                    var img = "Exception.png";
                    driver.GetScreenshot().SaveAsFile(img);
                    driver.Quit();
                    throw new Exception("Failed to complete test see image " + img, e);
                }
            }
        }
    }
}
