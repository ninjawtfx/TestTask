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
    public class CalculatorPage : BasePage
    {
        public CalculatorPage(IWebDriver browser)
            :base(browser)
        {
            this.driver = browser;

            url = "http://abbyy-ls.ru/doc-calculator";

            driver.Navigate().GoToUrl(url);

            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//*[@id=\"calculator\"]/form/div[2]/div[1]/div[2]/fieldset/div[2]/select[1]")]
        public IWebElement FromLangSelector { get; set; }

        [FindsBy(How = How.Name, Using = "to-lang")]
        public IWebElement ToLangSelector { get; set; }

        
    }
}
