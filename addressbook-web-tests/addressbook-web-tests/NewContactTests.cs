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
        navigator.GoToHomePage();
            //передаем параметры логин/пароль
        loginHelper.Login(new AccountData("admin", "secret"));
        navigator.GoToAddNewPage();
        NewContactData group = new NewContactData("Мария");
        contactHelper.FilAddNewForm(new NewContactData("Мария", "Попова"));
        contactHelper.EnterNewContactCreation();
        navigator.ReturToHomePage();
        loginHelper.Logout();
         }
    }
}
       
       
    

