using OpenQA.Selenium;
using AventStack.ExtentReports;
using Selenium_Test.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Test.Pages
{
    class AlertsPage
    {
        private readonly WebElementHelper helper;
        public AlertsPage(WebElementHelper helper)
        {
            this.helper = helper;
        }

        public void ClickOnAlertsAndWindows()
        {
            helper.ClickOnElement(helper.FindElement(By.XPath("//button[text()=' Alerts, Frames & Windows ']")));
            helper.test.Log(Status.Pass, "Click On Alerts, Frames & Windows", helper.CaptureScreenShot());
            helper.WaitForSeconds(2);
            
        }

        public void ClickOnAlerts()
        {
            helper.ClickOnElement(helper.FindElement(By.XPath("//a[text()=' Alerts']"))); 
            helper.test.Log(Status.Pass, "Click On Alerts", helper.CaptureScreenShot());
            helper.WaitForSeconds(2);
        }

        public void ClickOnAlertButton() {
            helper.ClickOnElement(helper.FindElement(By.XPath("(//button[text()='Click Me'])[2]")));
            helper.test.Log(Status.Pass, "Click On Alert Button");
            helper.WaitForSeconds(2);
        }

        public void DismissAlert()
        {
            helper.SwitchToAlertAndDismiss();
            helper.test.Log(Status.Pass, "Click On Alert Dismiss Button", helper.CaptureScreenShot());
            helper.WaitForSeconds(2);
        }

        public void AcceptAlert()
        {
            helper.SwitchToAlertAndAccept();
            helper.test.Log(Status.Pass, "Click On Alert Accept Button", helper.CaptureScreenShot());
            helper.WaitForSeconds(2);
        }
    }
}
