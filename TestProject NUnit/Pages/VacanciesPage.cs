using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace TestProject_NUnit.Pages
{
    public class VacanciesPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        public IWebElement DEPARTMENTS_BUTTON => driver.FindElement(By.XPath("//button[contains(text(),'All departments')]"));
        public IWebElement LANGUAGE_BUTTON => driver.FindElement(By.XPath("//button[contains(text(),'All languages')]"));
        public IWebElement RESEARCH_DEVELOPMENT_TAG => driver.FindElement(By.XPath("//a[contains(text(),'Research & Development')]"));
        public IWebElement ENGLISH_OPTION_TAG => driver.FindElement(By.XPath("//label[contains(text(),'English')]"));
        public IList<IWebElement> VACANCIES_LIST_TAG => driver.FindElements(By.XPath("//a[@class='card card-sm card-no-hover']"));
        public IWebElement COOKIES_ACCEPT_BUTTON => driver.FindElement(By.XPath("//div[@id='cookiescript_accept']"));

        public VacanciesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }


        public void clickDepartmentsButton()
        {
            wait.Until(c => DEPARTMENTS_BUTTON);

            DEPARTMENTS_BUTTON.Click();
        }

        public void clickLanguagesButton()
        {

            wait.Until(c => LANGUAGE_BUTTON);

            LANGUAGE_BUTTON.Click();
        }

        public void chooseDepartment(IWebElement department_tag)
        {
            wait.Until(c => department_tag);

            department_tag.Click();
        }

        public void chooseLanguage(IWebElement language_tag)
        {

            wait.Until(c => language_tag);

            language_tag.Click();
        }

        public void clickAcceptCookies()
        {
            wait.Until(c => COOKIES_ACCEPT_BUTTON);

            COOKIES_ACCEPT_BUTTON.Click();
        }
    }
}
