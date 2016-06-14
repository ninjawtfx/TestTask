using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Drawing;
using System.IO;
using NUnit.Framework;
using TestTask.Pages;

namespace TestTask.Tests
{
    public class TestBase
    {
        protected IWebDriver Driver;

        protected BasePage Page;

        static protected IWebDriver[] Browsers = Helpers.BrowsersList;

        protected string TestName;

        public TestBase(IWebDriver driver)
        {
            Driver = driver;
        }

        //Добавляем сохранение скриншота
        protected void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                var shot = ((ITakesScreenshot)Driver).GetScreenshot();

                Directory.CreateDirectory(@"C:\scrins");
                shot.SaveAsFile(string.Format(@"C:\scrins\{0}.jpeg", TestName), System.Drawing.Imaging.ImageFormat.Jpeg);

                

                throw;
            }
        
        }


    }
}
