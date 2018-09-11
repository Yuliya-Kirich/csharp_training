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

            

            NewContactData contact = new NewContactData("");
            contact.Firstname = "Елена";
            contact.Lastname = "Иванова";


            List<NewContactData> oldContact = app.Contact.GetContactList();


            app.Contact.Create(contact);

          //  Assert.AreEqual(oldContact.Count + 1, app.Contact.GetContactCount());

            List<NewContactData> newContact = app.Contact.GetContactList();

              oldContact.Add(contact);
              oldContact.Sort();
              newContact.Sort();
         
            Assert.AreEqual(oldContact, newContact);

          //  app.Auth.Logout();

            //app.Navigator.GoToAddNewPage(); перенесен в ContactHelper

            /*    app.Contact                  перенесен в ContactHelper
                    .FilAddNewForm(contact)
                    .EnterNewContactCreation();*/

            // app.Navigator.GoToHome(); перенесен в ContactHelper и заменен на ReturToHomePage();


        }
    }
}
       
       
    

