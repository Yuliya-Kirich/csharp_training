using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebAddressbookTests;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    class GroupCreationTests : /*TestBase*/  AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            //Без конструктора, но лучше понимаем, т.к. не надо помнить в каком порядке передаются 
           // app.Groups.InitGroupCreation();
          
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            // app.Navigator.GoToGroupsPage(); создан в навигатор и перемещен в GroupHelper
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.Create(group);

            /*.InitNewGroupCreation() Создан метод в GroupHelper. Тут мы ссылаемся на этот меод в котором содержатся все эти ссылки
            .FillGroupForm(group)
            .SubmitGroupCreation()
            .ReturnToGroupsPage();*/
            //Место, где объект конструируется   
            //В качестве параметра передается объект group
            // app.Auth.Logout();


            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            // Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            //groups.Count;
        }

        [Test]
        public void EnptyGroupCreationTest()
        {
            // Без конструктора, но лучше понимаем, т.к.не надо помнить в каком порядке передаются
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            //app.Navigator.GoToGroupsPage(); создан в навигатор и перемещен в GroupHelper

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            //Место, где объект конструируется   
            //В качестве параметра передается объект group
            app.Groups.Create(group);
            /*.InitNewGroupCreation()   Создан метод в GroupHelper. Тут мы ссылаемся на этот меод в котором содержатся все эти ссылки
            .FillGroupForm(group)
            .SubmitGroupCreation()
            .ReturnToGroupsPage();*/
            //app.Auth.Logout(); // выполнение следом за этим тестом

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }

}

