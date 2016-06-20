using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestTask.Pages
{
	public abstract class BasePage
	{
		//Наш главный драйвер, с которым работает страница
		protected IWebDriver _driver;
		//Наш адрес страницы
		protected string _url;
		//Объект для ожидания какого-либо эвента на странице
		protected WebDriverWait _wait;
		//Наш хэдер
		public Header HeaderPage;

		public abstract void Navigate();

		public BasePage(IWebDriver driver)
		{
			this._driver = driver;
			HeaderPage = new Header(this._driver);
		}

		public IWebDriver GetDriver()
		{
			return _driver;
		}
	}
}
