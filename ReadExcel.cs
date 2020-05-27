/*.......................................
 *  
 *  
 *  //Details For the code can be found here ...
     https://www.codeproject.com/Articles/1088970/Read-Write-Excel-file-with-OLEDB-in-Csharp-without
 * 
 * You need to install AccessDatabaseEngine (32 bit ) if you get below message ...
 * Message = "The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine."
 */



using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;       //microsoft Excel 14 object in references-> COM tab

namespace DotNet_Automation
{
    /// <summary>
    /// 1. Using OLEDB Provider
    /// Pro: it is fast, and it works even on machines where MS Excel is not installed.

//  //  2. Excel Interop Object
    //may be very slow, especially compared to option 1, and you need MS Excel to be installed. But you get complete access to Excel's object model, you can extract almost every information (for example: formatting information, colors, frames etc) that is stored in your Excel file and your sheets can be as complex structured as you want.
    /// </summary>
    public class ReadExcel
    {
        

        private static string fullPathToExcel = XmlHelper.GetElement("TestCaseFilePath");
        static string connString = string.Format(XmlHelper.GetElement("ExcelProvider"), fullPathToExcel);        

        /// <summary>
        ///Reading Excel with INTEROP/COM object....
        /// </summary>
        public static void ReadExcelUsing_InterOp()
        {

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(XmlHelper.GetElement("TestCaseFilePath"));
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1); //first  sheet...
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");//write the value to the console
                }
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }


        /// <summary>
        /// Get data table using OleDb
        /// parameters
        /// <sql>query</sql>
        /// <connectionString> Connection string to connect </connectionString>
        /// </summary>
        public static DataTable GetDataTable_OLE(string sheetName)

        {

            using (OleDbConnection conn = new OleDbConnection(connString))
            {

                conn.Open();
                OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter
                ("SELECT * from [" + sheetName + "$]", conn);// takes parameters query and connection object.
                DataSet excelDataSet = new DataSet();
                objDA.Fill(excelDataSet); // update the dataset.
                return excelDataSet.Tables[0];//will return the data table object

            }

        }


        // To Do ....

        public static void UpdateColumnValue(int row, string column, string sheetName)
        {


        }
    }
}