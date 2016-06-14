using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TestTask.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestTask.Tests
{
    [TestFixture, TestFixtureSource("browsers")]
    public class SliderTests : TestBase
    {
        public SliderTests(IWebDriver driver)
            :base(driver)
        {
                
        }

       

        [Test]
        public void SliderPictureChangeTest()
        {
            HomePage hp = new HomePage(Driver);
            

            UITest(() =>
            {
                TestName = "Нажатие на 5е меню слайдера";
                hp.Validate(5);
                TestName = "Нажатие на 4е меню слайдера";
                hp.Validate(4);
                TestName = "Нажатие на 3е меню слайдера";
                hp.Validate(3);
                TestName = "Нажатие на 2е меню слайдера";
                hp.Validate(2);
                TestName = "Нажатие на 1е меню слайдера";
                hp.Validate(1);
            });

        }

        static IWebDriver[] browsers = Helpers.BrowsersList;

    }
}
