using NUnit.Framework;
using TestProject_NUnit.Pages;

namespace TestProject_NUnit
{
    [TestFixture]
    internal class TestClass:BaseTest
    {
        [Test]
        [TestCase(5)]
        [TestCase(13)]

        public void CheckVacanciesAmount(int expected_amount,string department_option = null,
            string language_option = null)
        {
            var vacanciesPage = new VacanciesPage(driver);

            vacanciesPage.clickAcceptCookies();

            vacanciesPage.clickDepartmentsButton();

            vacanciesPage.chooseDepartment(vacanciesPage.RESEARCH_DEVELOPMENT_TAG);

            vacanciesPage.clickLanguagesButton();

            vacanciesPage.chooseLanguage(vacanciesPage.ENGLISH_OPTION_TAG);

            var vacancies_list =  vacanciesPage.VACANCIES_LIST_TAG;

            Assert.AreEqual(vacancies_list.Count,expected_amount);

        }
    }
}
