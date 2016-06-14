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
    [TestFixture, TestFixtureSource("TypesOfPages")]
    public class HeaderTestqs
    {
        private BasePage currentPage;

        private IWebDriver _driver;

        static public Type[] TypesOfPages = new Type[] {
            Type.GetType("TestTask.Pages.HomePage"),
            Type.GetType("TestTask.Pages.CalculatorPage"),
            Type.GetType("TestTask.Pages.VerbalTranslatePage")
        };

        public HeaderTestqs(Type page)
        {
            Browsers.Init();
            _driver = Browsers.Driver;

            currentPage = (BasePage)Activator.CreateInstance(page, _driver);
            currentPage.Navigate();
        }

        [Test]
        public void PhoneDisplayTest()
        {
            //TestName = "Проверка отображения телефона";
            Assert.IsTrue(currentPage.HeaderPage.PhoneBox.Displayed);

        }

        [Test]
        public void PhoneBoxHasTextTest()
        {
            //TestName = "Проверка того что телефон не пустой";
            Assert.IsTrue(currentPage.HeaderPage.PhoneBox.Text != string.Empty);

        }

        [Test]
        public void LanguaBoxDisplayTest()
        {

            //TestName = "Проверка того что выбор языка отображается";
            Assert.IsTrue(currentPage.HeaderPage.LanguaComboBox.Displayed);

        }

        [Test]
        public void LanguaElementsTest()
        {

            //TestName = "Проверка, что для выбора есть 4 элемента";
            currentPage.HeaderPage.LanguaComboBox.Click();

            Assert.IsTrue(currentPage.HeaderPage.FirstElemDropBox.Displayed
                          && currentPage.HeaderPage.SecondElemDropBox.Displayed
                          && currentPage.HeaderPage.ThirdElemDropBox.Displayed
                          && currentPage.HeaderPage.FourthElemDropBox.Displayed);

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
