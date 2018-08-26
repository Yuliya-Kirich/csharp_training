using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigatorHelper : HelperBase
    {
       
        protected string baseURL;

        public NavigatorHelper(ApplicationManager manager, string baseURL)
            :base(manager)
        {
            
            this.baseURL = baseURL;
        }


        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void GoToHome()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        


    }
}
