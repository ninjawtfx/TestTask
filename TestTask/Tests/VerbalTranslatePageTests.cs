using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TestTask.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TestTask.Tests
{
	[TestFixture]
	public class VerbalTranslatePageTests : TestBase
	{
		private VerbalTranslatePage _currentPage;

		[SetUp]
		public void InitBefore()
		{
			_currentPage = new VerbalTranslatePage(_driver);
			_currentPage.Navigate();
		}

		[TestCase(TestName = "Проверка, что лист с типом мероприятий не пустой")]
		public void TypeOrgListNotEmptyTest()
		{
			Assert.IsTrue(_currentPage.CheckSelectTypeOrganizationEmpty());
		}

		[TestCase(TestName = "Проверка, что можно выбрать элемент с value 1")]
		public void TypeOrgListCanSelectElemTest()
		{
			_currentPage.SelectTypeOrganizationOptionByVal("1");
			Assert.AreEqual("деловые переговоры", _currentPage.GetTypeOrganizationAsSE().SelectedOption.Text);
		}


	}

}
