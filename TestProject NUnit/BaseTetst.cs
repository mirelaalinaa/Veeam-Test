using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace TestProject_NUnit
{
    [TestFixture]
    public class BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://cz.careers.veeam.com/vacancies";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
