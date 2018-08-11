using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebAddressbookTests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            //передается не два значения, отдельно, а один объект
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitNewGroupCreation();

            //Без конструктора, но лучше понимаем, т.к. не надо помнить в каком порядке передаются 
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            //Место, где объект конструируется   
            //В качестве параметра передается объект group
            app.Groups.FillGroupForm(group);

            app.Groups.SubmitGroupCreation();
            app.Groups.ReturToGroupPage();
            app.Auth.Logout();
        }
    }
}

