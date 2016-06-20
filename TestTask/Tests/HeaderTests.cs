using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestTask.Pages;
using System.Collections;
using OpenQA.Selenium;
using System.Reflection;
using System.Configuration;
using System.Drawing.Imaging;
using NUnit.Framework.Interfaces;

namespace TestTask.Tests
{
	[TestFixture, TestFixtureSource("_typesOfPages")]
	public class HeaderTests
	{
		private BasePage _currentPage;

		private IWebDriver _driver;

		static private Type[] _typesOfPages = new Type[] {
            Type.GetType("TestTask.Pages.HomePage"),
            Type.GetType("TestTask.Pages.CalculatorPage"),
            Type.GetType("TestTask.Pages.VerbalTranslatePage")
        };

		public HeaderTests(Type page)
		{
			Browsers.Init();
			_driver = Browsers.Driver;

			_currentPage = (BasePage)Activator.CreateInstance(page, _driver);
			_currentPage.Navigate();
		}

		[Test]
		public void PhoneDisplayTest()
		{
			//TestName = "Проверка отображения телефона";
			Assert.IsTrue(_currentPage.HeaderPage.PhoneBox.Displayed);

		}

		[Test]
		public void PhoneBoxHasTextTest()
		{
			//TestName = "Проверка того что телефон не пустой";
			Assert.IsTrue(_currentPage.HeaderPage.PhoneBox.Text != string.Empty);

		}

		[Test]
		public void LanguaBoxDisplayTest()
		{

			//TestName = "Проверка того что выбор языка отображается";
			Assert.IsTrue(_currentPage.HeaderPage.LanguaComboBox.Displayed);

		}

		[Test]
		public void LanguaElementsTest()
		{

			//TestName = "Проверка, что для выбора есть 4 элемента";
			_currentPage.HeaderPage.LanguaComboBox.Click();

			Assert.IsTrue(_currentPage.HeaderPage.FirstElemDropBox.Displayed
						  && _currentPage.HeaderPage.SecondElemDropBox.Displayed
						  && _currentPage.HeaderPage.ThirdElemDropBox.Displayed
						  && _currentPage.HeaderPage.FourthElemDropBox.Displayed);

		}

		[TearDown]
		public void OneTearDown()
		{
			if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
			{
				Screenshot scr = ((ITakesScreenshot)_driver).GetScreenshot();
				scr.SaveAsFile(string.Format(@"{0}/Header.jpeg",
				   ConfigurationManager.AppSettings["pathToScreens"]), ImageFormat.Jpeg);
			}
		}

		[TestFixtureTearDown]
		public void TearDown()
		{
			if (_driver != null)
			{
				_driver.Quit();
			}
		}



	}



}
