﻿using System;
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
    public class LoginHelper : HelperBase
    {
        
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        
        public void Login(AccountData account)
        {
            //1)если мы уже залогинены (не известно под какой учетной записью
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }


            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

       
        /*    Модифицирован
         *    
         *    
         *    
                //Какие бы параметры мы не добавили, Login принимает один параметр,(объект) типа AccountData
                //параметризованный логин, может входить с любым логином/паролем
                public void Login(AccountData account)
                {
                    //Используем только нужные свойства объекта, остальные игнорируем. В тех местах, в которым они нужны будут использоваться дополнительные свойства

                    driver.FindElement(By.Name("user")).Clear();
                    //                                          вводятся значения свойств объекта (Username, Password) AccountData
                    driver.FindElement(By.Name("user")).SendKeys(account.Username);
                    driver.FindElement(By.Name("pass")).Clear();
                    //В поля вводятся значения свойств этого объекта
                    driver.FindElement(By.Name("pass")).SendKeys(account.Password);
                    driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
                }
                */


        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click(); //если мы не залогинены, то Logout делать не надо
            }

           // driver.FindElement(By.LinkText("Logout")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
           
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                    == "(" + account.Username + ")";

        }

    }
}
