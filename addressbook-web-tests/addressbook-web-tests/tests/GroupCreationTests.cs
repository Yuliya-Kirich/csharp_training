using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebAddressbookTests;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    class GroupCreationTests : /*TestBase*/  AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for(int i=0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))//максимальная длина строки, которую хотим сгенерировать
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)

                });

            }
        return groups;
        }

        public static IEnumerable<GroupData> /*GroupDataFromFile()*/ GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach(string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2],
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
          
        }

        // [Test, TestCaseSource("RandomGroupDataProvider")]
        [Test, TestCaseSource("GroupDataFromFile")]
        public void GroupCreationTest(GroupData group)
        {
            //Без конструктора, но лучше понимаем, т.к. не надо помнить в каком порядке передаются 
            // app.Groups.InitGroupCreation();

            /* GroupData group = new GroupData("aaa");   инициализация тестовых данных не нужна, т.к. добавлен параметр в GroupCreationTes
             group.Header = "ddd";
             group.Footer = "fff";*/

            // app.Navigator.GoToGroupsPage(); создан в навигатор и перемещен в GroupHelper
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
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
            Assert.AreEqual(oldGroups , newGroups);
            // Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            //groups.Count;
        }

       /* [Test]
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
            //int count = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            /*.InitNewGroupCreation()   Создан метод в GroupHelper. Тут мы ссылаемся на этот меод в котором содержатся все эти ссылки
            //.FillGroupForm(group)
           // .SubmitGroupCreation()
           // .ReturnToGroupsPage();
            //app.Auth.Logout(); // выполнение следом за этим тестом

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups , newGroups);
        }*/ //Убираем полностью тест, это задача генераторов тестовых данных
    }

}

