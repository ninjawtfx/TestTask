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

        [Test]
        public void TypeOrgListNotEmptyTest()
        {
            _testName = "Проверка, что лист с типом мероприятий не пустой";
            Assert.IsTrue(_currentPage.CheckSelectTypeOrganizationEmpty());
        }

        [Test]
        public void TypeOrgListCanSelectElemTest()
        {
            _testName = "Проверка, что можно выбрать элемент с value 1";
            _currentPage.SelectTypeOrganizationOptionByVal("1");
            Assert.AreEqual("деловые переговоры", _currentPage.GetTypeOrganizationAsSE().SelectedOption.Text);
        }


    }

}
