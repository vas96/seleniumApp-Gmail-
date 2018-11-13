using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMExample.PageObjects;

namespace POMExample
{
    public class TestClass
    {
        private IWebDriver _driver;

        private readonly string _toSubject = "Lab3";
        private readonly string _toText = "Lorem ..................";
        
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [TestCase("lab1antaltest@gmail.com", "987QWERTY", "antal_lviv@rambler.ru")]
        [TestCase("lab1antaltest@gmail.com", "987QWERTY", "anyvas21@gmail.com")]
        public void lab3Gmail(params string[] patametrs)
        {
            LogInPage logInPage = new LogInPage(driver: _driver);
            logInPage.GoToPage();

            PasswordPage passwordPage = logInPage.GoToPasswordPage(email: patametrs[0]);
          
            ChooseGmilPage chooseMailPage = passwordPage.GoToMidPage(password: patametrs[1]);

            GmailPage mailPage = chooseMailPage.GoToGmailPage();

            mailPage.toCompose();
            mailPage.fillFieldsAndSend(to: patametrs[2],subject: _toSubject,text: _toText);
            mailPage.openSended();
            mailPage.checkSended(@from: patametrs[2],text: _toText);         
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
