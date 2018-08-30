using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper: HelperBase
    {
       

        public ContactHelper(ApplicationManager manager) 
            :base(manager)
        {
        }

        public ContactHelper Modify(int v, NewContactData newData)
        {
            manager.Navigator.GoToHomePage();
            //manager.Navigator.GoToHome();
            // SelectContact();  //не нужен. зато добавлен индекс для  InitContactModification
            CheckTheExistenceOfaContact();
            InitContactModification(1);
            FilAddNewForm(newData);
            SubmitGroupModification();
            ReturToHomePage();

            return this;
        }

        public ContactHelper Create(NewContactData contact)
        {

            manager.Navigator.GoToAddNewPage(); //Перенесен из NewContactTest
            FilAddNewForm(contact);
            EnterNewContactCreation();
            ReturToHomePage();
            return this;
            
        }

        public ContactHelper RemoveNewContact()
        {
            manager.Navigator.GoToHomePage();
            CheckTheExistenceOfaContact();
            SelectContact();
            RemoveContact();
            return this;
        }


        
            public ContactHelper FilAddNewForm(NewContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
           
            return this;
        }

        /* Модифицировали
                public ContactHelper FilAddNewForm(NewContactData contact)
                {
                    driver.FindElement(By.Name("firstname")).Clear();
                    driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
                    driver.FindElement(By.Name("lastname")).Clear();
                    driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
                    return this;
                }
        */

        public ContactHelper EnterNewContactCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        public ContactHelper SelectContact()
        {
            //driver.FindElement(By.Id("6")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])[1]")).Click();
            driver.SwitchTo().Alert().Accept();

            return this;
        }

        public ContactHelper ReturToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }


        public ContactHelper SubmitGroupModification()
        {
            driver.FindElement(By.XPath("(//input[@value='Update'])")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            //driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();

            return this;
        }


        public ContactHelper CheckTheExistenceOfaContact()
        {

            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])")))
            {
                return this;
            }

            NewContactData contact = new NewContactData("");
            contact.Firstname = "Test Name";
            contact.Lastname = "Test Lastname";
            Create(contact);

            return this;
        }

    }
}
