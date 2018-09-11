using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
       
        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }



        public GroupHelper Create(GroupData group)
        {

            manager.Navigator.GoToGroupsPage(); //Перенесен из GroupCreationTest

            InitNewGroupCreation();
            FillGroupForm(group);
            // RemoveGroup();
            SubmitGroupCreation();
            ReturnToGroupsPage();
            //  SelectGroup(1);
            return this;
        }
        


        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                //внутри span находим input, и внутри одного элемента ищем другой, смотрим атрибут value
                foreach (IWebElement element in elements)
                {
                    //в локальную переменную сохраняем ссылку на объект. Затем присваиваем свойства. Заием полученную группу с таким идентификатором добавлять в список
                    groupCache.Add(new GroupData(element.Text){
                       Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                     });
                }
            }
                    

            return new List<GroupData>(groupCache);

        }




        public int GetGroupCount()
        {
           return  driver.FindElements(By.CssSelector("span.group")).Count;
        }

        /*
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                List<GroupData> groups = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    // GroupData group = new GroupData (element.Text));
                    groups.Add(new GroupData(element.Text));
                }
            }

            return new List<GroupData>(groupCache);
        }

*/

        public GroupHelper Modify(int v, GroupData newData)
        {
           
           // manager.Navigator.GoToGroupsPage();
           // CheckTheExistenceOfaGroup();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        

        public GroupHelper Remove(int v)
        {
            //manager.Navigator.GoToGroupsPage();
            //CheckTheExistenceOfaGroup();
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

       

        /* public GroupHelper Select (GroupData group) //сама напиала
         {
             manager.Navigator.GoToHomePage();
             RemoveGroup();  //вытащила из метода GroupHelper Create(GroupData group)
             SelectGroup(1);
             return this;
         }*/



        public GroupHelper SelectGroup(int index)
        {
            // driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();  //по С# перепишем
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index +1) + "]")).Click();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }



        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[1]")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            /*1) By locator = By.Name("group_name"); //Временно вынесли в переменные  и создали из двух строчек новый метод
            string text = group.Name;
            Type(locator, text);*/

            
            Type(By.Name("group_name"), group.Name); // 2) убрать локальные переменные 
            Type(By.Name("group_header"), group.Header);// 3) проделать то же самое с остальными
            Type(By.Name("group_footer"), group.Footer);
            


            /*driver.FindElement(By.Name("group_name")).Clear();   // модифицировать, убрать лишние строки (в пунктах 1-3 описание)
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);*/
            return this;
        }

/*
        //реализуем нужную нам функциональность  
        public void Type(By locator, string text)                 //Переносим в HelperBase
        {
            if(text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }


        }
*/


        /*
        private void Type(By locator, string text)    // перенесено в условие (если, то)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }*/

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        /*
        public GroupHelper CheckTheExistenceOfaGroup()
        {
            
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])")))
            {    
                return this;
            }

            GroupData group = new GroupData("test1");
            group.Header = "test1.1";
            group.Footer = "test1.1.1";
            Create(group);
           
            return this;
        }

    */

    }
}
