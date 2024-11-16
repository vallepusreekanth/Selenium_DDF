using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_Test.utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Model;

namespace Selenium_Test.tests
{
    public class BaseClass
    {
        private ExtentReports extentReports;
        private ThreadLocal<ExtentTest> extent_test = new ThreadLocal<ExtentTest>();
        private WebDriver driver;
        protected WebElementHelper helper;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            string testclassfilename = TestContext.CurrentContext.Test.ClassName;
            string dir = System.Environment.CurrentDirectory;
            string projdir = Directory.GetParent(dir).Parent.FullName;
            string timeStamp = DateTime.Now.ToString("dd_MM_yyyy_h_mm_ss");
            string fileName = testclassfilename + "_" + timeStamp;
            string reporpath = projdir + "\\Reports\\" + fileName + ".html";
            var htmlreport = new ExtentSparkReporter(reporpath);
            htmlreport.LoadJSONConfig("../../Utilities/extent_config.json");
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlreport);
            extentReports.AddSystemInfo("Enivorment", "QA");

        }

        [SetUp]
        public void SetUp() {
            test = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
            extent_test.Value = test;
            driver = new ChromeDriver();
            helper = new WebElementHelper(driver, test);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.tutorialspoint.com/selenium/practice/selenium_automation_practice.php");
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                var stackTrace = TestContext.CurrentContext.Result.StackTrace;
                DateTime date = DateTime.Now;
                string Filename = "Screenshot_" + date.ToString("h_mm_ss") + ".png";
                extent_test?.Value?.Fail("TestCase Status : Failed", CaptureScreenShot(driver, Filename));
                extent_test?.Value?.Fail(stackTrace);
            }
            else if (status == TestStatus.Passed)
            {
                extent_test.Value.Log(Status.Pass, MarkupHelper.CreateLabel("TestCase Status : " + status, ExtentColor.Green));
            }
            extentReports.Flush();
            driver.Close();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            
        }

        public Media CaptureScreenShot(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot scr = (ITakesScreenshot)driver;
            var screenshot = scr.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }

    }
}
