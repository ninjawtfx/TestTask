using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace TestTask.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected string url;

        public Header HeaderPage;


        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            HeaderPage = new Header(this.driver);
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
    }
}
