using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
namespace TestTask
{
    public class Browsers
    {
        public static IWebDriver Driver;
        public static void Init()
        { 
            
            switch(ConfigurationManager.AppSettings["browser"])
            {
                case "firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "chrome":
                    Driver = new ChromeDriver();
                    break;
                case "ie":
                    Driver = new InternetExplorerDriver();
                    break;
        };}
    }
}
