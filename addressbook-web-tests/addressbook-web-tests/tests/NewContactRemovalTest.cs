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
    class NewContactRemovalTests : TestBase
    {
       


        [Test]
        public void NewContactRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Contact
                .SelectContact(1)
                .RemoveContact();
        }
    }
}

