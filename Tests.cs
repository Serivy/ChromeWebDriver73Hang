using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;

namespace WebDriverTest
{
    public class Tests
    {
        [NUnit.Framework.Test]
        public void RunTest()
        {
            using (var driver = new ChromeDriver())
            {
                // This line is what causes the issue
                driver.Manage().Window.Size = new Size(1024, 663);

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
