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
    [TestFixture]
    public class SelectLangTests : TestBase
    {
        private CalculatorPage page;

        static private string[] fromLangTexts = new string[] { "Русск" };
        static private string[] toLangTexts = new string[] { "Англ" };

        [SetUp]
        public void InitBefore()
        {
            page = new CalculatorPage(_driver);
            page.Navigate();
        }

        [Test]
        public void EmptySelectFromLangTest()
        {
            _testName = "Проверка на пустой список с языка перевода";
            Assert.IsTrue(page.CheckFromLangSelectorEmpty());
        }

        [Test]
        public void EmptySelectToLangTest()
        {
            _testName = "Проверка на пустой список с языка на который переводить";
            Assert.IsTrue(page.CheckToLangSelectorEmpty());
        }

        [Test, TestCaseSource("fromLangTexts")]
        public void SelectFromLangTest(string text)
        {
            _testName = "Проверка на выбор языка с которого переводим";
            string selectedText = page.SelectFromLangOption(text);
            Assert.AreEqual(selectedText, page.GetFromLangAsSE().SelectedOption.Text);
        }

        [Test, TestCaseSource("toLangTexts")]
        public void SelectToLangTest(string text)
        {
            _testName = "Проверка на выбор языка на который переводим";
            string selectedText = page.SelectToLangOption(text);
            Assert.AreEqual(selectedText, page.GetFromLangAsSE().SelectedOption.Text);

        }
    }
}
