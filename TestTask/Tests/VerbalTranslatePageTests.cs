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
        private VerbalTranslatePage currentPage;

        [SetUp]
        public void InitBefore()
        {
            currentPage = new VerbalTranslatePage(Driver);
            currentPage.Navigate();
        }

        [Test]
        public void TypeOrgListNotEmptyTest()
        {
                TestName = "Проверка, что лист с типом мероприятий не пустой";
                Assert.IsTrue(currentPage.CheckSelectTypeOrganizationEmpty());
        }

        [Test]
        public void TypeOrgListCanSelectElemTest()
        {
                TestName = "Проверка, что можно выбрать элемент с value 1";
                currentPage.SelectTypeOrganizationOptionByVal("1");
                //Sleep(1);
                Assert.AreEqual("деловые переговоры", currentPage.GetTypeOrganizationAsSE().SelectedOption.Text);
        }
        

    }

}
