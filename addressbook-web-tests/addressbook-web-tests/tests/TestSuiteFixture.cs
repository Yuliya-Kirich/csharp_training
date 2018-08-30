using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]

    public class TestSuiteFixture
    {
       // public static ApplicationManager app;

        [SetUp]

        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        /* создан метод в ApplicationManager - ~ApplicationManager(), который не предпологает дополнительных методов для его вызова
         * 
         * [TearDown]
         public void StopApplicationManager()
         {
             //app.Stop();
             ApplicationManager.GetInstance().Stop();
         }
         */
    }
}
