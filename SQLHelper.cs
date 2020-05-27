using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using DotNet_Automation.Helper;

namespace DotNet_Automation
{

    // DataReader
    //The ADO.NET DataReader is used to retrieve read-only(cannot update data back to a datasource) and forward-only(cannot read backward/random) data from a database.
    //Using of a DataReader increases application performance and reduces system overheads. This is due to one row at a time is stored in memory.
    //You create a DataReader by calling Command.ExecuteReader after creating an instance of the Command object. 
    //This is a connected architecture: The data is available as long as the connection with database exists.
    //You need to open and close the connecton manually in code.



//    DataSet
//The DataSet is a in-memory representation of data.
//It can be used with multiple data sources.That is A single DataSet can hold the data from different data sources holdng data from different databases/tables.
//The DataSet represents a complete set of data including related tables, constraints, and relationships among the tables.
//The DataSet can also persist and reload its contents as XML and its schema as XML Schema definition language (XSD) schema.
//The DataAdapter acts as a bridge between a DataSet and a data source for retrieving and saving data. 
//The DataAdapter helps mapping the data in the DataSet to match the data in the data source.
//Also, Upon an update of dataset, it allows changing the data in the data source to match the data in the DataSet. 
//No need to manually open and close connection in code.
//Hence, point (8) says that it is a disconnected architecture.Fill the data in DataSet and that's it. No connection existence required

    public class SQLHelper
    {

      
        /// <summary>
        /// using SqlDataReader
        /// </summary>
        /// <returns></returns>
        /// 

        public SQLHelper()
        {
         
        }

        public string getColumnValue()
        {
            string value = null;

            string connectionString = "User ID = SATURNE_DBO; Password = sqlSQL123; Server = azas-s903lw; Database = SaturneMobile; Connection Timeout = 50;";

            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                conn.Open(); //must for SqlDataReader 
                SqlCommand cmd = new SqlCommand("select * from dbo.SE_DECOUPAGE", conn);

               

                using (SqlDataReader rdr = cmd.ExecuteReader()) // builds SqlDataReader
                {
                    //SqlDataReader -->forward only stream of rows
                    while (rdr.Read())
                    {
                        value = rdr["DEC_CODE"].ToString();
                    }
                }


            }
            Console.WriteLine(value);
         
            return value;

        }

        /// <summary>
        /// using data set
        /// </summary>
        /// <returns></returns>
        public string GetColumnValue()
        {
            string value = null;
            string connectionString = "User ID = SATURNE_DBO; Password = sqlSQL123; Server = azas-s903lw; Database = SaturneMobile; Connection Timeout = 50;";

            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                SqlDataAdapter da = new SqlDataAdapter("select * from dbo.SE_DECOUPAGE ", conn); //represents SQL commands and connection 
                da.SelectCommand.CommandType = System.Data.CommandType.Text; //we can pass SP also..
                DataSet ds = new DataSet();

                da.Fill(ds);

                value = ds.Tables[0].Rows[0]["DEC_CODE"].ToString();
            }
            Console.WriteLine(value);

            return value;

        }



    }




}
