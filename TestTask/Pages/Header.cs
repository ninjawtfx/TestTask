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
    public class Header
    {
        //Наш драйвер, который мы получаем со страницы
        private readonly IWebDriver _driver;
        public Header(IWebDriver driver)
        {
            this._driver = driver;

            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//*[@id=\"block-block-21\"]/div/div/div[1]")]
        public IWebElement LanguaComboBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"block-block-21\"]/div/div/div[2]")]
        public IWebElement LanguaDropBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"block-block-21\"]/div/div/div[2]/noindex[1]/a")]
        public IWebElement FirstElemDropBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"block-block-21\"]/div/div/div[2]/noindex[2]/a")]
        public IWebElement SecondElemDropBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"block-block-21\"]/div/div/div[2]/noindex[3]/a")]
        public IWebElement ThirdElemDropBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"block-block-21\"]/div/div/div[2]/noindex[4]/a")]
        public IWebElement FourthElemDropBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"block-block-14\"]/div/div/p")]
        public IWebElement PhoneBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"block-block-21\"]/div/div/div[1]/span[2]/span")]
        public IWebElement SelectedLanguaText { get; set; }


    }
}



