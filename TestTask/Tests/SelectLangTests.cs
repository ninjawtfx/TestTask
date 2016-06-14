using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestTask.Pages;
using System.Collections;
using OpenQA.Selenium;


namespace TestTask.Tests
{
    [TestFixture, TestFixtureSource("Browsers")]
    public class SelectLangTests : TestBase
    {
        private CalculatorPage page;

        static private string[] fromLangTexts = new string[] { "Русск" };
        static private string[] toLangTexts = new string[] { "Англ" };

        public SelectLangTests(IWebDriver driver)
            :base(driver)
        {
            page = new CalculatorPage(Driver);
        }
        [Test]
        public void EmptySelectFromLangTest()
        {
            UITest(() =>
            {
                TestName = "Проверка на пустой список с языка перевода";
                Helpers.ValidateBoolTrue(Helpers.CheckListEmpty(page.FromLangSelector));
            });
        }

        [Test]
        public void EmptySelectToLangTest()
        {
            UITest(() =>
            {
                TestName = "Проверка на пустой список с языка на который переводить";
                Helpers.ValidateBoolTrue(Helpers.CheckListEmpty(page.ToLangSelector));
            });
        }

        [Test, TestCaseSource("fromLangTexts")]
        public void SelectFromLangTest(string text)
        {
            UITest(() =>
            {
                TestName = "Проверка на выбор языка с которого переводим";
                Helpers.SelectItemInList(page.FromLangSelector, text);
                Helpers.Sleep(1);
                Helpers.ValidateBoolTrue(Helpers.CheckOptionSelected(page.FromLangSelector, text));
            });
        }

        [Test, TestCaseSource("toLangTexts")]
        public void SelectToLangTest(string text)
        {
            UITest(() =>
            {
                TestName = "Проверка на выбор языка на который переводим";
                Helpers.SelectItemInList(page.ToLangSelector, text);
                Helpers.Sleep(1);
                Helpers.ValidateBoolTrue(Helpers.CheckOptionSelected(page.ToLangSelector, text));
            });
        }
    }
}
