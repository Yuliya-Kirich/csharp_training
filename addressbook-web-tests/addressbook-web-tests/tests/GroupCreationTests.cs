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
            //Без конструктора, но лучше понимаем, т.к. не надо помнить в каком порядке передаются 
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            //Место, где объект конструируется   
            //В качестве параметра передается объект group
            app.Groups.Create(group);
            app.Auth.Logout();
        }

        [Test]
        public void EnptyGroupCreationTest()
        {
            // Без конструктора, но лучше понимаем, т.к.не надо помнить в каком порядке передаются
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            //Место, где объект конструируется   
            //В качестве параметра передается объект group
            app.Groups.Create(group);
            app.Auth.Logout();
        }
    }

}

