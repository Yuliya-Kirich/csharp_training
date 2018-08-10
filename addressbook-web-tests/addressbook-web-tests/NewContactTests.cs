using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    class NewContactTests : TestBase
    {

        [Test]
        public void NewContactTest()
        {
        GoToHomePage();
        //передаем параметры логин/пароль
        Login(new AccountData("admin", "secret"));
        GoToAddNewPage();
        NewContactData group = new NewContactData("Мария");
        FilAddNewForm(new NewContactData("Мария", "Попова"));
        EnterNewContactCreation();
        ReturToHomePage();
        Logout();
         }
    }
}
       
       
    

