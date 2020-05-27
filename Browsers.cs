using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

using System;

namespace DotNet_Automation.Selenium
{
    class Browsers
    {


        public static IWebDriver setBrowserDriver(string path,string browserName)
        {
            IWebDriver driver = null;

              try
            {
                switch (browserName.ToUpper())
                {
                    case "CHROME":

                        ChromeOptions option = new ChromeOptions();
                        //option.AddArgument("--headless");
                        option.AddArgument("start-maximized");
                        option.AddUserProfilePreference("download.prompt_for_download", true);
                        driver = new ChromeDriver(path, option);

                        break;
                    case "IE":

                        var options = new InternetExplorerOptions();
                        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        driver = new InternetExplorerDriver(options);

                        break;

                }
            }
            catch (Exception)
            { }

            return driver;
        }
    }
}
