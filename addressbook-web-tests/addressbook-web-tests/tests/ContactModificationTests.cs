using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : TestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            NewContactData newContData = new NewContactData("") ;
            newContData.Firstname = "Анна";
            newContData.Lastname = "Заморочкина";

        app.Contact.Modify(1, newContData);

        }

    }
}
