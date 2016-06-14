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
    public class VerbalTranslatePage : BasePage
    {

        public VerbalTranslatePage(IWebDriver browser)
            :base(browser)
        {
            this.driver = browser;
            url = "http://abbyy-ls.ru/interpreting_offer";
            driver.Navigate().GoToUrl(url);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "edit-submitted-event-type")]
        public IWebElement SelectTypeOrganization { get; set; }

    }
}
