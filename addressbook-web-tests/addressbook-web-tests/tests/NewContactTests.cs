using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    class NewContactTests : /*TestBase*/  AuthTestBase
    {

        [Test]
        public void NewContactTest()
        {

            List<NewContactData> oldContact = app.Contact.GetContactList();

            NewContactData contact = new NewContactData("");
            contact.Firstname = "Елена";
            contact.Lastname = "Иванова";


            app.Contact.Create(contact);

            List<NewContactData> newContact = app.Contact.GetContactList();

            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact.Count + 1, newContact.Count);

            app.Auth.Logout();

            //app.Navigator.GoToAddNewPage(); перенесен в ContactHelper

            /*    app.Contact                  перенесен в ContactHelper
                    .FilAddNewForm(contact)
                    .EnterNewContactCreation();*/

            // app.Navigator.GoToHome(); перенесен в ContactHelper и заменен на ReturToHomePage();


        }
    }
}
       
       
    

