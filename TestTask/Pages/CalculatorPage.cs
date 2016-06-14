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
            : base(browser)
        {
            this._driver = browser;
            _url = "http://abbyy-ls.ru/doc-calculator";
        }

        public override void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"calculator\"]/form/div[2]/div[1]/div[2]/fieldset/div[2]/select[1]")]
        public IWebElement FromLangSelector { get; set; }

        [FindsBy(How = How.Name, Using = "to-lang")]
        public IWebElement ToLangSelector { get; set; }

        public bool CheckFromLangSelectorEmpty()
        {
            SelectElement se = new SelectElement(FromLangSelector);
            return se.Options.Any();
        }

        public bool CheckToLangSelectorEmpty()
        {
            SelectElement se = new SelectElement(ToLangSelector);
            return se.Options.Any();
        }

        public string SelectFromLangOption(string text)
        {
            SelectElement se = new SelectElement(FromLangSelector);
            string selectedText = se.Options.Where(x => x.Text.Contains(text)).FirstOrDefault().Text;
            se.SelectByText(selectedText);
            return selectedText;
        }

        public string SelectToLangOption(string text)
        {
            SelectElement se = new SelectElement(ToLangSelector);
            string selectedText = se.Options.Where(x => x.Text.Contains(text)).FirstOrDefault().Text;
            se.SelectByText(selectedText);
            return selectedText;
        }

        public SelectElement GetFromLangAsSE()
        {
            return new SelectElement(FromLangSelector);
        }

        public SelectElement GetToLangAsSE()
        {
            return new SelectElement(ToLangSelector);
        }
    }
}
