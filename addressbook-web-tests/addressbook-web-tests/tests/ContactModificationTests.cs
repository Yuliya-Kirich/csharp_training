using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;




namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : /*TestBase*/  AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GoToHomePage();
            //manager.Navigator.GoToHome();
            // SelectContact();  //не нужен. зато добавлен индекс для  InitContactModification
            app.Helper.CheckTheExistenceOfaContact();


            NewContactData newContData = new NewContactData("") ;
            newContData.Firstname = "Анна";
            newContData.Lastname = "Заморочкина";

            List<NewContactData> oldContact = app.Contact.GetContactList();

            app.Contact.Modify(0, newContData);

            List<NewContactData> newContact = app.Contact.GetContactList();

            oldContact[0].Lastname = newContData.Lastname;
            oldContact[0].Firstname = newContData.Firstname;
            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);

        }

    }
}
