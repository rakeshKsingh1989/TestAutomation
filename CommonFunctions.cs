using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Xml;
using System.IO;
using OpenQA.Selenium.Support.UI;
using DotNet_Automation.Selenium;
using System.Data;

namespace DotNet_Automation
{



    public class CommonFunctions
    {


        private  IWebDriver driver;
        private  string driverloc;
        private  DataTable dt;

        /// <summary>
        /// WAit for element 
        /// </summary>
        [Obsolete]
        public static IWebElement WaitForElementVisible(IWebDriver driver , By element)
        {
            var foundElement = new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(ExpectedConditions.ElementIsVisible(element));
            return foundElement;
        }


        public IWebDriver LaunchUrl()
        {
            driverloc = XmlHelper.GetElement("chrome");
            driver = Browsers.setBrowserDriver(driverloc, "chrome");
            dt = ReadExcel.GetDataTable_OLE("Login");
            driver.Navigate().GoToUrl(dt.Rows[0]["AppURL"].ToString());
            return driver;
        }





    }
}
 