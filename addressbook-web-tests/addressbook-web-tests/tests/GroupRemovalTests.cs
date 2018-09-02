using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]
    class GroupRemovalTests : /*TestBase*/  AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            app.Navigator.GoToGroupsPage();
            app.Groups.CheckTheExistenceOfaGroup();

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);

            /* app.Navigator.GoToGroupsPage();  перенесен в GroupHelper в метод Remove
             app.Groups.SelectGroup(1);
             app.Groups.RemoveGroup();
             app.Groups.ReturnToGroupsPage();*/
            /*.SelectGroup(1)
        .RemoveGroup()
         .ReturnToGroupsPage();*/

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

