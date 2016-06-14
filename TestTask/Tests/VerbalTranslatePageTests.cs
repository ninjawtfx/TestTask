using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TestTask.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TestTask.Tests
{
    [TestFixture, TestFixtureSource("Browsers")]
    public class VerbalTranslatePageTests : TestBase
    {
        private VerbalTranslatePage currentPage;

        public VerbalTranslatePageTests(IWebDriver driver)
            :base(driver)
        {
            currentPage = new VerbalTranslatePage(Driver);
        }

        [Test]
        public void TypeOrgListNotEmptyTest()
        {
            UITest(() =>
            {
                TestName = "Проверка, что лист с типом мероприятий не пустой";
                Helpers.ValidateBoolTrue(Helpers.CheckListEmpty(currentPage.SelectTypeOrganization));
            });
        }

        [Test]
        public void TypeOrgListCanSelectElemTest()
        {
            UITest(() =>
            {
                TestName = "Проверка, что можно выбрать элемент с value 1";
                Helpers.SelectItemInListByValue(currentPage.SelectTypeOrganization, "1");

                Helpers.Sleep(1);
                Helpers.ValidateBoolTrue(Helpers.CheckOptionSelectedByValue(currentPage.SelectTypeOrganization, "1"));
            });
        }


    }

}
