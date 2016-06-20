using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TestTask.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestTask.Tests
{
	[TestFixture]
	public class SliderTests : TestBase
	{
		private HomePage _currentPage;

		[SetUp]
		public void InitBefore()
		{
			_currentPage = new HomePage(_driver);
			_currentPage.Navigate();
		}

		[TestCase(TestName = "Нажатие на 5е меню слайдера")]
		public void SliderPictureChangeTest()
		{
			_currentPage.ValidateSliderImageChange(5);
		}

	}
}
