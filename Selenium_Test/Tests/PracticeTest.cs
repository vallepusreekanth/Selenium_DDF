using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_Test.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Test.tests
{
    [TestFixture]
    public class PracticeTest: BaseClass
    {
        [Test]
        public void Alerts()
        {
            helper.ClickOnElement(helper.FindElement(By.XPath("//button[text()=' Alerts, Frames & Windows ']")));
            helper.WaitForSeconds(5);
            helper.ClickOnElement(helper.FindElement(By.XPath("//a[text()=' Alerts']")));
            helper.WaitForSeconds(5);
            helper.ClickOnElement(helper.FindElement(By.XPath("(//button[text()='Click Me'])[3]")));
            helper.WaitForSeconds(5);
            helper.SwitchToAlertAndEnterText("srikanth");
            helper.WaitForSeconds(5);

        }

        [Test]
        public void AcceptAndDismissAlerts()
        {
            AlertsPage alertsPage = new AlertsPage(helper);

            alertsPage.ClickOnAlertsAndWindows();
            alertsPage.ClickOnAlerts();
            alertsPage.ClickOnAlertButton();
            alertsPage.AcceptAlert();
            alertsPage.ClickOnAlertButton();
            alertsPage.DismissAlert();
        }
    }
}
