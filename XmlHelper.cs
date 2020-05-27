using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Xml;
using System.IO;

namespace DotNet_Automation
{
       


    public class XmlHelper
    {
       static string elementValue = "";             
      

        public static string GetElement(string element)
        {

            try
            {
                // new xdoc instance 
                XmlDocument xDoc = new XmlDocument();

                //load up the xml from the location 
                xDoc.Load(@"C:\Automation\DotNet_Automation\Interview_UnitPrograms\Data\AppConfig.xml");

                // cycle through each child noed 
                foreach (XmlNode node in xDoc.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode locNode in node)
                    {
                        // thereare a couple child nodes here so only take data from node named loc 
                        if (locNode.Name.ToLower() == element.ToLower())
                        {
                            // get the content of the loc node 
                            elementValue = locNode.InnerText;

                        }    
                        
                    }
                }
            }
            catch { }

            return elementValue.Trim().Replace("/",@"\");

        }

       
    }






}
 