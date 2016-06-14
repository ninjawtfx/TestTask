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
        private HomePage currentPage;

        [SetUp]
        public void InitBefore()
        {
            currentPage = new HomePage(Driver);
            currentPage.Navigate();
        }

        [Test]
        public void SliderPictureChangeTest()
        {
            TestName = "Нажатие на 5е меню слайдера";
            currentPage.Validate(5);
        }

    }
}
