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
using OpenQA.Selenium.Firefox;
using NUnit.Common;
using NUnit.Framework.Interfaces;
using System.Configuration;
using System.Drawing.Imaging;

namespace TestTask.Tests
{

    [TestFixture]
    public abstract class TestBase
    {
        protected IWebDriver Driver;

        protected BasePage Page;

        protected string TestName;

        static protected List<BasePage> Pages = new List<BasePage>();

        [TestFixtureSetUp]
        public void Init()
        {
            Browsers.Init();
            Driver = Browsers.Driver;
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        [TearDown]
        public void OneTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot scr = ((ITakesScreenshot)Driver).GetScreenshot();
                scr.SaveAsFile(string.Format(@"{0}/{1}.jpeg",
                   ConfigurationManager.AppSettings["pathToScreens"],
                   TestName), ImageFormat.Jpeg);
            }
        }




    }
}
