using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Xml;
using System.IO;
using OpenQA.Selenium.Support.PageObjects;
using DotNet_Automation.Selenium;
using System.Data;

namespace DotNet_Automation
{
       
    /// <summary>
    /// Class for holding all page objects...
    /// </summary>

    public class HomePage
    {        
       
       
        public static By SearchTextBox = By.XPath("//*[@id='sitesearch_field']");

        public static By SearchButton = By.XPath("//*[@id='headerSearchForm']/a/img");

        public static By SearchResult = By.XPath("/html/body/div[2]/div[3]/div[1]/div[2]/div[2]/h3");       

        public static By BookFound = By.ClassName("bookTitle");
        
                     
    }




}
 