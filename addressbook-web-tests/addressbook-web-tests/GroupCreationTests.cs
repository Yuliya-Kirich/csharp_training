using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebAddressbookTests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            //передается не два значения, отдельно, а один объект
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();

            //Без конструктора, но лучше понимаем, т.к. не надо помнить в каком порядке передаются 
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            //Место, где объект конструируется   
            //В качестве параметра передается объект group
            FillGroupForm(group);

            SubmitGroupCreation();
            ReturToGroupPage();
            Logout();
        }
    }
}

