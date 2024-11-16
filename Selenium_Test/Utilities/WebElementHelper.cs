using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Selenium_Test.utilities
{
    public class WebElementHelper
    {
        private readonly WebDriver driver;
        public readonly ExtentTest test;
        public WebElementHelper(WebDriver driver, ExtentTest test) { 
            this.driver = driver;
            this.test = test;
        }

        public void WaitForSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public void ClickOnElement(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch(Exception error) {
                Console.WriteLine($"Click on element {element} failed");
                test.Log(Status.Fail, error.Message);
                throw error;
            }
        }

        public IWebElement FindElement(By selector)
        {
            try
            {
                return driver.FindElement(selector);
            }
            catch (Exception error)
            {
                Console.WriteLine("Element not found");
                test.Log(Status.Fail, $"Element not found {selector.ToString()}");
                throw error;
            }
        }

        public void SelectElementByIndex(WebElement element, int index)
        {
            try
            {
                SelectElement sel = new SelectElement(element);
                sel.SelectByIndex(index);
            }
            catch (Exception error)
            {
                test.Log(Status.Fail, $"Select Dropdown By Index Failed {error.Message}");
            }
        }

        public void SelectElementByValue(WebElement element, string value)
        {
            try
            {
                SelectElement sel = new SelectElement(element);
                sel.SelectByValue(value);
            }
            catch (Exception error)
            {
                test.Log(Status.Fail, $"Select Dropdown By Value Failed {error.Message}");
            }
        }

        public void SelectElementByText(WebElement element, string text)
        {
            try
            {
                SelectElement sel = new SelectElement(element);
                sel.SelectByText(text);
            }
            catch (Exception error)
            {
                test.Log(Status.Fail, $"Select Dropdown By Value Failed {error.Message}");
            }
        }

        public void SwitchToAlertAndEnterText(string text)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.SendKeys(text);
                alert.Accept();
            }
            catch (Exception error)
            {
                test.Log(Status.Fail, $"Switch To Alert And Enter Text {error.Message}");
            }
        }

        public void SwitchToAlertAndAccept()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (Exception error)
            {
                test.Log(Status.Fail, $"Switch To Alert Ans Accept Failed {error.Message}");
            }
        }
        public void SwitchToAlertAndDismiss()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Dismiss();
            }
            catch (Exception error)
            {
                test.Log(Status.Fail, $"Switch To Alert Failed And Dismiss {error.Message}");
            }
        }

        public Media CaptureScreenShot()
        {
            ITakesScreenshot scr = (ITakesScreenshot)driver;
            var screenshot = scr.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build();
        }
    }
}
