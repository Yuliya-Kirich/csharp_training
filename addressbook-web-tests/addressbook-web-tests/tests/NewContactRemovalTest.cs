using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    class NewContactRemovalTests : /*TestBase*/  AuthTestBase
    {
       


        [Test]
        public void NewContactRemovalTest()
        {

            app.Navigator.GoToHomePage();
            app.Helper.CheckTheExistenceOfaContact();

            List<NewContactData> oldContact = app.Contact.GetContactList();

            app.Contact.RemoveNewContact();


            List<NewContactData> newContact = app.Contact.GetContactList();

            oldContact.RemoveAt(0);

            Assert.AreEqual(oldContact, newContact);
            /*app.Navigator.GoToHomePage(); перенесено в ContactHelper
            app.Contact
                .SelectContact(1)
                .RemoveContact();*/
        }
    }
}

