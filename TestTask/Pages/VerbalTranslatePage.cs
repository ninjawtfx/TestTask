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
	public class VerbalTranslatePage : BasePage
	{

		public VerbalTranslatePage(IWebDriver browser)
			: base(browser)
		{
			this._driver = browser;
			_url = "http://abbyy-ls.ru/interpreting_offer";
		}

		public override void Navigate()
		{
			_driver.Navigate().GoToUrl(_url);
			PageFactory.InitElements(_driver, this);
		}

		[FindsBy(How = How.Id, Using = "edit-submitted-event-type")]
		public IWebElement SelectTypeOrganization { get; set; }

		public bool CheckSelectTypeOrganizationEmpty()
		{
			SelectElement se = new SelectElement(SelectTypeOrganization);
			return se.Options.Any();
		}

		public void SelectTypeOrganizationOptionByVal(string val)
		{
			SelectElement se = new SelectElement(SelectTypeOrganization);
			se.SelectByValue(val);
		}

		public SelectElement GetTypeOrganizationAsSE()
		{
			return new SelectElement(SelectTypeOrganization);
		}


	}
}
