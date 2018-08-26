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
            SelectContact(v);
            InitContactModification();
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

        public ContactHelper RemoveNewContact(int v)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
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

        public ContactHelper SelectContact(int index)
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

        public ContactHelper InitContactModification()
        {
            //driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[2]")).Click();

            return this;
        }
    }
}
