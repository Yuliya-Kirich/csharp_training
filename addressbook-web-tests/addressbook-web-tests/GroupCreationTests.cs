using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebNewContactTests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            //передается не два значения, отдельно, а один объект
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();

            //Без конструктора, но лучше понимаем, т.к. не надо помнить в каком порядке передаются 
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            //Место, где объект конструируется   
            //В качестве параметра передается объект group
            FillGroupForm(group);

            SubmitGroupCreation();
            ReturToGroupPage();
            Logaut();
        }

        private void Logaut()
        {            
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        //Передаем параметр, как объект
        private void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            //А во всех остальных местах, где это свойство не используется, никаких изменений вносить не надо
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);                    
           //driver.FindElement(By.Name("group_footer")).Clear();
           //driver.FindElement(By.Name("group_footer")).SendKeys(footer);
        }

        private void InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        //Какие бы параметры мы не добавили, Login принимает один параметр,(объект) типа AccountData
        private void Login(AccountData account)
        {
            //Используем только нужные свойства объекта, остальные игнорируем. В тех местах, в которым они нужны будут использоваться дополнительные свойства

            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            //В поля вводятся значения свойств этого объекта
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

