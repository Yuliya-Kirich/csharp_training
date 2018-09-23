using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace WebAddressbookTests
{
    [TestFixture]
    public class ContacDetailstInformationTests : AuthTestBase
    {
        [Test]

        public void ContacDetailstInformationTest()
        {
            NewContactData fromTable = app.Contact.GetContactInformationTable(0);
            NewContactData fromDetails = app.Contact.GetContactInformationDetails(0);

            Assert.AreEqual(fromTable, fromDetails);
            Assert.AreEqual(fromTable.Address, fromDetails.Address);
            Assert.AreEqual(fromTable.AllPhones, fromDetails.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromDetails.AllEmails);
        }
    }
}
