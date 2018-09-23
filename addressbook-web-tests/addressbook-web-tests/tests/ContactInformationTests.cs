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

    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            //получить информацию оюб отдельно взятом контакте. возвращает объект типа  NewContactData

            NewContactData fromTable = app.Contact.GetContactInformationTable(0);
            NewContactData fromForm = app.Contact.GetContactInformationForm(0);

            //затем смогу сравнивать данные контакта

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);


        }
    }
}
