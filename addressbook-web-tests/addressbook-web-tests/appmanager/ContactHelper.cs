using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


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
          /*  manager.Navigator.GoToHomePage();
            //manager.Navigator.GoToHome();
            // SelectContact();  //не нужен. зато добавлен индекс для  InitContactModification
            CheckTheExistenceOfaContact();*/
            InitContactModification(0);
            FilAddNewForm(newData);
            SubmitGroupModification();
            ReturToHomePage();

            return this;
        }


        public NewContactData GetContactInformationDetails(int index)
        {
            manager.Navigator.Gotohome();
            InitiateContactDetailsViewing(0);
            //string[] nameParts = driver.FindElement(By.CssSelector("#content b: nth-child [1]")).Text.Split(' ');
             string[] nameParts = driver.FindElement(By.CssSelector("div#content b")).Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
             string firstname = nameParts[0];
             string lastname = nameParts[1];


            //IList<IWebElement> cells = driver.FindElements(By.CssSelector("div#content br:nth-of-type(3)"));

            //IList<IWebElement> cells = driver.FindElements(By.XPath("div [@id = 'content']/following-sibling::br[3]"));
            //input[@id='username']/following-sibling::input[1]
            //IList<IWebElement> cells = driver.FindElements(By.CssSelector("div#content"));            
            // string allPhones = cells[0].Text;
            /*  string[] namebrParts = driver.FindElement(By.CssSelector("div#content")).Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
              string address = namebrParts[12];*/
            // string address;

            //  string allEmail;

            string[] namebrParts = driver.FindElement(By.CssSelector("div#content")).Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string address = namebrParts[1];            
            string homePhone = namebrParts[3];
            string mobilePhone = namebrParts[4];
            string workPhone = namebrParts[5];
            string allPhones = namebrParts[3] + namebrParts[4] + namebrParts[5];
            string email = namebrParts[7];
            string email2 = namebrParts[8];
            string email3 = namebrParts[9];
            string emails = namebrParts[7] + namebrParts[8] + namebrParts[9];

            return new NewContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
               //llPhones = allPhones,
                //AllEmail = allEmail;
            };

            /* IList<IWebElement> cells = driver.FindElements(By.Id("content"))[index]
                   .FindElements(By.TagName("br"));*/



        }


        public NewContactData GetContactInformationForm(int index)
        {
            manager.Navigator.Gotohome();
            InitContactModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new NewContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };

        } 

        public NewContactData GetContactInformationTable(int index)
        {
            manager.Navigator.Gotohome();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;  //фамилия хранится в фчейке с индексом 1
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text; // все тлефоны одновременно
            string allemails = cells[4].Text;

            return new NewContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allemails,
            };

        }

        private List<NewContactData> contactCache = null;

        public List<NewContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<NewContactData>(); 
                manager.Navigator.Gotohome();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
                int counter = 0;
                foreach (IWebElement element in elements)
                {
                    if (counter > 0)
                    {
                        string secondbox = element.FindElement(By.XPath("td[3]")).Text;
                        string firstbox = element.FindElement(By.XPath("td[2]")).Text;


                        contactCache.Add(new NewContactData(secondbox, firstbox));
                    }
                    counter++;
                }
            }

            return new List<NewContactData>(contactCache);  
        }


        /* 
         * public List<NewContactData> GetContactList()
         {

            List<NewContactData> contact = new List<NewContactData>(); // contacts

             manager.Navigator.Gotohome();

             ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
             int counter = 0;
             foreach (IWebElement element in elements)
             {
                 if (counter > 0)
                 {
                     string secondbox = element.FindElement(By.XPath("td[3]")).Text;
                     string firstbox = element.FindElement(By.XPath("td[2]")).Text;


                     contact.Add(new NewContactData(secondbox, firstbox));
                 }
                 counter++;
             }

             return contact;  // contacts
         }
     */
     /*
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr #entry")).Count;
            //div#container div#content form table#maintable.sortcompletecallback-applyZebra tbody tr
        }
        */










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
           // manager.Navigator.GoToHomePage();
           // CheckTheExistenceOfaContact();
            SelectContact(0);
            RemoveContact();
            return this;
        }


        
            public ContactHelper FilAddNewForm(NewContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);           
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);           
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);            

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
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            //driver.FindElement(By.Id("6")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])[1]")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;

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
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            //driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            // driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index) + "]")).Click(); переписано по С#
            // driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();

            return this;
        }


/*
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
        */

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactHelper InitiateContactDetailsViewing(int index)
        {
            driver.FindElement(By.CssSelector("img[alt=\"Details\"]")).Click();
           /* driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();*/
            return this;
        }
    }
}
