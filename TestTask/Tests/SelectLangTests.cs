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

		static private string[] _fromLangTexts = new string[] { "Русск" };
		static private string[] _toLangTexts = new string[] { "Англ" };

		[SetUp]
		public void InitBefore()
		{
			page = new CalculatorPage(_driver);
			page.Navigate();
		}

		[TestCase(TestName = "Проверка на пустой список с языка перевода")]
		public void EmptySelectFromLangTest()
		{
			Assert.IsTrue(page.CheckFromLangSelectorEmpty());
		}

		[TestCase(TestName = "Проверка на пустой список с языка на который переводить")]
		public void EmptySelectToLangTest()
		{
			Assert.IsTrue(page.CheckToLangSelectorEmpty());
		}

		[TestCase(TestName = "Проверка на выбор языка с которого переводим"), TestCaseSource("_fromLangTexts")]
		public void SelectFromLangTest(string text)
		{	
			string selectedText = page.SelectFromLangOption(text);
			Assert.AreEqual(selectedText, page.GetFromLangAsSE().SelectedOption.Text);
		}
		
		[TestCase(TestName = "Проверка на выбор языка на который переводим"), TestCaseSource("_toLangTexts")]
		public void SelectToLangTest(string text)
		{
			string selectedText = page.SelectToLangOption(text);
			Assert.AreEqual(selectedText, page.GetFromLangAsSE().SelectedOption.Text);
		}
	}
}
