using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using TestTask.Pages;
using System.Threading;
using System.Reflection;
using OpenQA.Selenium.Support.UI;

namespace TestTask
{
    static public class Helpers
    {
        //Папка с нашими драйверами
        static private string pathToDrivers = @"C:\drivers";

        static public string GetElemStyle(IWebElement elem)
        {
            return elem.GetAttribute("style");
        }

        static public void ValidateString(string objExpected, string objActual)
        {
            Assert.AreEqual(objExpected, objActual);
        }
        static public void ValidateBoolTrue(bool el)
        {
            Assert.IsTrue(el);
        }

       //Все драйверы, которые используем для тестов
       static public readonly IWebDriver[] BrowsersList = 
        {
            new ChromeDriver(pathToDrivers),
            new FirefoxDriver(),
            new InternetExplorerDriver(pathToDrivers),
          //  new OperaDriver(),
          //  new SafariDriver()
        };


       //Получаем массив со всеми страницами(которые указываем в теле метода) со всеми драйверами, которые храним в массиве BrowsersList
       static public BasePage[] GetAllPagesOnAllDrivers()
       { 

           List<BasePage> list = new List<BasePage>();

           //Можно с помощью рефлексии найти всех кто наследует BasePage, подходит если много страниц и нужна просто автоматизация
           
           foreach (var driver in BrowsersList)
           {
               list.Add(new HomePage(driver));
               list.Add(new CalculatorPage(driver));
               list.Add(new VerbalTranslatePage(driver));
           }

           return list.ToArray();
       }

       //Проверка есть ли опция для выбора в элементе по указаному тексту
       static public void SelectItemInList(IWebElement elem, string text)
       {
           SelectElement list = new SelectElement(elem);

           var ss = list.Options.Where(x => x.Text.Contains(text)).FirstOrDefault();

           list.SelectByText(list.Options.Where(x => x.Text.Contains(text)).FirstOrDefault().Text);
       }

       //Проверка есть ли опция для выбора в элементе по указаному value
       static public void SelectItemInListByValue(IWebElement elem, string val)
       {
           SelectElement list = new SelectElement(elem);
           list.SelectByValue(val);
       }

       //Проверка на пустой элемент Select : true - есть элементы в списке, false - нет 
       static public bool CheckListEmpty(IWebElement elem)
       {
           SelectElement list = new SelectElement(elem);
           return list.Options.Any();
       }

       //Проверка выбрана ли(selected) опция с текстом, который передается в элементе
       static public bool CheckOptionSelected(IWebElement elem, string text)
       {
           SelectElement list = new SelectElement(elem);
           return list.Options.Where(x => x.Text.Contains(text)).FirstOrDefault().Selected;
       }


       //Проверка выбрана ли(selected) опция с value, который передается в элементе
       static public bool CheckOptionSelectedByValue(IWebElement elem, string val)
       {
           SelectElement list = new SelectElement(elem);
           return list.Options.Where(x => x.GetAttribute("value") == val).FirstOrDefault().Selected;
       }

       static public void Sleep(double seconds)
       {
           Thread.Sleep(TimeSpan.FromSeconds(seconds));
       }
    }
}
