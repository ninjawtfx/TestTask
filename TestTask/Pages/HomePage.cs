using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace TestTask.Pages
{
	//Главная страница 
	public class HomePage : BasePage
	{
		//Делаем связь через справочник, дабы избежать много if'ов и свитча
		private Dictionary<IWebElement, IWebElement> _sliderRelations = new Dictionary<IWebElement, IWebElement>();

		public HomePage(IWebDriver browser)
			: base(browser)
		{
			_driver = browser;
			_url = @"http://abbyy-ls.ru/";
			_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
		}

		public override void Navigate()
		{
			_driver.Navigate().GoToUrl(_url);

			PageFactory.InitElements(_driver, this);

			_sliderRelations.Add(FirstItemSlider, FirstImageSlider);
			_sliderRelations.Add(SecondItemSlider, SecondImageSlider);
			_sliderRelations.Add(ThirdItemSlider, ThirdImageSlider);
			_sliderRelations.Add(FourthItemSlider, FourthImageSlider);
			_sliderRelations.Add(FifthItemSlider, FifthImageSlider);
		}

		#region leftMenuSlider
		//Управление переводом
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[1]/ul/li[1]/a")]
		public IWebElement FirstItemSlider { get; set; }

		//Снижение издержек
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[1]/ul/li[2]/a")]
		public IWebElement SecondItemSlider { get; set; }

		//Инновация сервиса
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[1]/ul/li[3]/a")]
		public IWebElement ThirdItemSlider { get; set; }

		//Качество перевода
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[1]/ul/li[4]/a")]
		public IWebElement FourthItemSlider { get; set; }

		//Автоматизация процессов
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[1]/ul/li[5]/a")]
		public IWebElement FifthItemSlider { get; set; }

		#endregion

		#region rightMenuSlider(Images)
		//Управление переводом - картинка
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[2]/div/div[1]")]
		public IWebElement FirstImageSlider { get; set; }

		//Снижение издержек - картинка
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[2]/div/div[2]")]
		public IWebElement SecondImageSlider { get; set; }

		//Инновация сервиса - картинка
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[2]/div/div[3]")]
		public IWebElement ThirdImageSlider { get; set; }

		//Качество перевода - картинка
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[2]/div/div[4]")]
		public IWebElement FourthImageSlider { get; set; }

		//Автоматизация переводов - картинка
		[FindsBy(How = How.XPath, Using = "//*[@id=\"slider\"]/div[2]/div/div[5]")]
		public IWebElement FifthImageSlider { get; set; }

		#endregion


		public void PushLeftItemSlider(IWebElement elem)
		{
			elem.Click();
		}
		
		//Метод проверки выбора меню на слайдере и сопоставления картинки, принимает порядковый номер елемента на слайдере
		public void ValidateSliderImageChange(int key)
		{
			//Для удобства, т.к. справочник начинается с 0
			key--;

			if (key >= 0 && key < _sliderRelations.Count)
			{
				PushLeftItemSlider(_sliderRelations.ElementAt(key).Key);
				_wait.Until(w => w.FindElement(By.TagName(
					_sliderRelations.ElementAt(key).Value.TagName))
					.Displayed);
				Assert.IsTrue((_sliderRelations.ElementAt(key).Value.Displayed));
			}
		}
	}
}
