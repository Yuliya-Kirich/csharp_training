using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : /*TestBase*/  AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups.CheckTheExistenceOfaGroup();

            GroupData newData = new GroupData("zzz");
            newData.Header = null; //"ttt";
            newData.Footer = null; //"qqq";


            

            app.Groups.Modify(1, newData);
        }
    }
}
