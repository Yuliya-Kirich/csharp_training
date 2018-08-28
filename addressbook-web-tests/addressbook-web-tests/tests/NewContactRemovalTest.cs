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
    [TestFixture]
    class NewContactRemovalTests : TestBase
    {
       


        [Test]
        public void NewContactRemovalTest()
        {
            app.Contact.RemoveNewContact();

            /*app.Navigator.GoToHomePage(); перенесено в ContactHelper
            app.Contact
                .SelectContact(1)
                .RemoveContact();*/
        }
    }
}

