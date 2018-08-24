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
           // app.Groups.InitGroupCreation();
          
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            // app.Navigator.GoToGroupsPage(); создан в навигатор и перемещен в GroupHelper
            
            app.Groups.Create(group);

                /*.InitNewGroupCreation() Создан метод в GroupHelper. Тут мы ссылаемся на этот меод в котором содержатся все эти ссылки
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();*/
            //Место, где объект конструируется   
            //В качестве параметра передается объект group
           
        }

        [Test]
        public void EnptyGroupCreationTest()
        {
            // Без конструктора, но лучше понимаем, т.к.не надо помнить в каком порядке передаются
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            //app.Navigator.GoToGroupsPage(); создан в навигатор и перемещен в GroupHelper

            //Место, где объект конструируется   
            //В качестве параметра передается объект group
            app.Groups.Create(group);
            /*.InitNewGroupCreation()   Создан метод в GroupHelper. Тут мы ссылаемся на этот меод в котором содержатся все эти ссылки
            .FillGroupForm(group)
            .SubmitGroupCreation()
            .ReturnToGroupsPage();*/
            app.Auth.Logout();
        }
    }

}

