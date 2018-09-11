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


            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0]; // информация для проверки запоминается заранее

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //Нужно проверить, что изменился тот именно элемент, что был указан в условии
            // т.е. идентификатор элемента находим и проверяем, что его имя стало таким, каким должно было стать
            foreach(GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
            //Все, что будем использовать в проверках, нужно сохранить заранее, чтобы безопасно использовать эти данные в проверках
            //Элемент с нулевым идентификатором, это тот который был до сортировки, и именно он должен меняться
            //т.к. мы пересортировали список, 1 элемент взять нельзя. Поэтому вся информация для теста должна быть заполнена заранее.
        }

    }
}
