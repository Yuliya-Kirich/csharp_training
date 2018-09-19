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
            contact.Address = "г. Москва, ул. Нижняя Никитская д. 17/15, кв. 13";
            contact.HomePhone = "8 (495) 655 55";
            contact.MobilePhone = "89250360121";
            contact.WorkPhone = "7 (495) 171717 ";
            contact.Email = "65555@gmail.com";
            contact.Email2 = "65555@er.mail";
            contact.Email3 = "65555@l.bk";



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
       
       
    

