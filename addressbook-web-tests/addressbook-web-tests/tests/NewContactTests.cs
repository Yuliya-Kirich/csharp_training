using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class NewContactTests : TestBase
    {

        [Test]
        public void NewContactTest()
        {
            

            app.Navigator.GoToAddNewPage();
           NewContactData contact = new NewContactData("");
            contact.Firstname = "Елена";
            contact.Lastname = "Иванова";

            app.Contact                 
                .FilAddNewForm(contact)
                .EnterNewContactCreation();

        app.Navigator.ReturToHomePage();
        app.Auth.Logout();

        }
    }
}
       
       
    

