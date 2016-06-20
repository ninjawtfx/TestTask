using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Drawing;
using System.IO;
using NUnit.Framework;
using TestTask.Pages;
using OpenQA.Selenium.Firefox;
using NUnit.Common;
using NUnit.Framework.Interfaces;
using System.Configuration;
using System.Drawing.Imaging;

namespace TestTask.Tests
{

	[TestFixture]
	public abstract class TestBase
	{
		protected IWebDriver _driver;

		protected BasePage _page;

		protected string _testName;

		static protected List<BasePage> _pagesList = new List<BasePage>();

		[TestFixtureSetUp]
		public void Init()
		{
			Browsers.Init();
			_driver = Browsers.Driver;
		}

		[TestFixtureTearDown]
		public void TearDown()
		{
			if (_driver != null)
			{
				_driver.Quit();
			}
		}

		[TearDown]
		public void OneTearDown()
		{
			if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
			{
				Screenshot scr = ((ITakesScreenshot)_driver).GetScreenshot();
				scr.SaveAsFile(string.Format(@"{0}/{1}.jpeg",
				   ConfigurationManager.AppSettings["pathToScreens"],
				   _testName), ImageFormat.Jpeg);
			}
		}




	}
}
