using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;






namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }

        public bool IsElementPresent(By by)   //дозаписать
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



        public void CheckTheExistenceOfaGroup()
        {

            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])")))
            {
                return;
            }

            GroupData group = new GroupData("test1");
            group.Header = "test1.1";
            group.Footer = "test1.1.1";
            manager.Groups.Create(group);

            return;
        }

        public void CheckTheExistenceOfaContact()
        {

            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])")))
            {
                return;
            }

            NewContactData contact = new NewContactData("");
            contact.Firstname = "Test Name";
            contact.Lastname = "Test Lastname";
            manager.Contact.Create(contact);

            return;
        }
    }   

}