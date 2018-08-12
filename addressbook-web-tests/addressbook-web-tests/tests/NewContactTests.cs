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
        NewContactData group = new NewContactData("Мария");
            app.Contact
                    .EnterNewContactCreation();

        app.Contact.FilAddNewForm(new NewContactData("Мария", "Попова"));
        app.Navigator.ReturToHomePage();
        app.Auth.Logout();
         }
    }
}
       
       
    

