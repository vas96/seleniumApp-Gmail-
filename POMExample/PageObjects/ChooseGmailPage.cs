using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;

namespace POMExample.PageObjects
{
    class ChooseGmilPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        
        public ChooseGmilPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'WaidBe')]")]
        private IWebElement _gmailElement;

        public GmailPage GoToGmailPage()
        { 
            _wait.Until(ExpectedConditions.ElementToBeClickable(_gmailElement));
            System.Threading.Thread.Sleep(1000);

            _gmailElement.Click();
            return new GmailPage(_driver);
        }
    }
}