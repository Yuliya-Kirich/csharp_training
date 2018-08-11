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
        app.Navigator.GoToHomePage();
            //передаем параметры логин/пароль
        app.Auth.Login(new AccountData("admin", "secret"));
        app.Navigator.GoToAddNewPage();
        NewContactData group = new NewContactData("Мария");
        app.Contact.FilAddNewForm(new NewContactData("Мария", "Попова"));
        app.Contact.EnterNewContactCreation();
        app.Navigator.ReturToHomePage();
        app.Auth.Logout();
         }
    }
}
       
       
    

