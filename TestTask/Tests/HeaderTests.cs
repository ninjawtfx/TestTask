using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestTask.Pages;
using System.Collections;
using OpenQA.Selenium;


namespace TestTask.Tests
{
    [TestFixture, TestFixtureSource("pages")]
    public class HeaderTests : TestBase
    {
        static private readonly BasePage[] pages = Helpers.GetAllPagesOnAllDrivers();

        private BasePage currentPage;

        public HeaderTests(BasePage page)
            :base(page.GetDriver())
        {
            currentPage = page;
        }

        [Test]
        public void PhoneDisplayTest()
        {
            UITest(() =>
            {
                TestName = "Проверка отображения телефона";
                Assert.IsTrue(currentPage.HeaderPage.PhoneBox.Displayed);
            });
        }

        [Test]
        public void PhoneBoxHasTextTest()
        {
            UITest(() =>
            {
                TestName = "Проверка того что телефон не пустой";
                Assert.IsTrue(currentPage.HeaderPage.PhoneBox.Text != string.Empty);
            });
        }

        [Test]
        public void LanguaBoxDisplayTest()
        {
            UITest(() =>
            {
                TestName = "Проверка того что выбор языка отображается";
                Assert.IsTrue(currentPage.HeaderPage.LanguaComboBox.Displayed);
            });
        }

        [Test]
        public void LanguaElementsTest()
        {
            UITest(() =>
            {
                TestName = "Проверка, что для выбора есть 4 элемента";
                currentPage.HeaderPage.LanguaComboBox.Click();

                Assert.IsTrue(currentPage.HeaderPage.FirstElemDropBox.Displayed
                              && currentPage.HeaderPage.SecondElemDropBox.Displayed
                              && currentPage.HeaderPage.ThirdElemDropBox.Displayed
                              && currentPage.HeaderPage.FourthElemDropBox.Displayed);
            });
        }
    
    
    }

    

}
