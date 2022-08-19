using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;



namespace TestProject_NUnit
{
    class VacanciesPage
    {
        String url = "https://cz.careers.veeam.com/vacancies";

        private IWebDriver driver;
        private WebDriverWait wait;

        public VacanciesPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }



    }
}
