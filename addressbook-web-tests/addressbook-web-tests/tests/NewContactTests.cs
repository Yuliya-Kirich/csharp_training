using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class NewContactTests : TestBase
    {

        [Test]
        public void NewContactTest()
        {

            NewContactData contact = new NewContactData("");
            contact.Firstname = "Елена";
            contact.Lastname = "Иванова";

            app.Contact.Create(contact);
            app.Auth.Logout();

            //app.Navigator.GoToAddNewPage(); перенесен в ContactHelper

            /*    app.Contact                  перенесен в ContactHelper
                    .FilAddNewForm(contact)
                    .EnterNewContactCreation();*/

            // app.Navigator.GoToHome(); перенесен в ContactHelper и заменен на ReturToHomePage();


        }
    }
}
       
       
    

