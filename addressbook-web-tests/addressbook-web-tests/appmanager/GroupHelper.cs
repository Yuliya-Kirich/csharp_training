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

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
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
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }





    }
}
