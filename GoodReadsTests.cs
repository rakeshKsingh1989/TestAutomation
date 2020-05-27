using DotNet_Automation.Helper;
using DotNet_Automation.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Data;

namespace DotNet_Automation
{

    [TestFixture]

    [Parallelizable]
    public class GoodReadsTests: HomePage
    {
        private IWebDriver driver;        
        private DataTable searchBook;
        CommonFunctions common;
        private ILog ilog;
        ITakesScreenshot screenshot;  

        [SetUp]
        public void LaunchUrl()
        {
            ilog = Logger.GetInstance;
            common = new CommonFunctions();
            driver = common.LaunchUrl();
        }




        [Test]
        [Obsolete]
        public void SearchBookName()
        {
           

            searchBook = ReadExcel.GetDataTable_OLE("SearchBook"); // Get test data from excel sheet

            try
            {

                driver.FindElement(SearchTextBox).SendKeys(searchBook.Rows[0]["Quotes"].ToString()); // Get input data from excel 
                driver.FindElement(SearchButton).Click();

                IWebElement searchResult = CommonFunctions.WaitForElementVisible(driver, SearchResult); //Dynamic wait


                if (searchResult.Text.Contains("No results"))
                {
                    ilog.LogInfo("No book found for given input .please change the search parameters");

                }
                
                else if (searchResult.Text.Contains("Page 1 of about 1 results"))
                {
                    ilog.LogInfo("Found 1 book for given input. the book name is : " + driver.FindElement(BookFound).Text.ToString());

                }

                else
                {
                    ilog.LogException("Found more than 1 book for given input. please refine the  search parameters");
                   
                }


            }

            catch (Exception ex)
            {
                ilog.LogException("Found exception during test execution : " + ex.Message);
                screenshot = driver as ITakesScreenshot;
                screenshot.GetScreenshot().SaveAsFile(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Error.jpeg");
            }

        }



        [TearDown]
        public void TearDown()
        {

           driver.Quit();

        }
    }
}



