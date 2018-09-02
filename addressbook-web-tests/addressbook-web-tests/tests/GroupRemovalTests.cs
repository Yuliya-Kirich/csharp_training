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
    class GroupRemovalTests : /*TestBase*/  AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            app.Navigator.GoToGroupsPage();
            app.Groups.CheckTheExistenceOfaGroup();


            app.Groups.Remove(1);


       /* app.Navigator.GoToGroupsPage();  перенесен в GroupHelper в метод Remove
        app.Groups.SelectGroup(1);
        app.Groups.RemoveGroup();
        app.Groups.ReturnToGroupsPage();*/
                 /*.SelectGroup(1)
             .RemoveGroup()
              .ReturnToGroupsPage();*/
        }
    }
}

