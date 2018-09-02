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


            app.Contact.Modify(1, newContData);

        }

    }
}
