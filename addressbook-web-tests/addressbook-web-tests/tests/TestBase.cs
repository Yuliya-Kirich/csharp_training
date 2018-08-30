using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
  public class TestBase 
    {
        protected ApplicationManager app;

        [SetUp]
        public void /*SetupTest()*/ SetupAplicationManager()
        {

            // app = new ApplicationManager(); //заменяем

            //app = TestSuiteFixture.app;

            app = ApplicationManager.GetInstance(); //1 уровень - инициализируется ApplicationManager
           // app.Auth.Login(new AccountData("admin", "secret"));  перенесен в класс AuthTestBase

            /* Перемещается в TestSuiteFixture
             * 
             * //передается не два значения, отдельно, а один объект
             app.Navigator.GoToHomePage();
             app.Auth.Login(new AccountData("admin", "secret"));*/
        }

       /* [TearDown] // метод можно удалить, т.к. осуществлен перенос
        public void TeardownTest()
        {
           // app.Stop(); Перенесено в TestSuiteFixture
        }
        */
       
    }
}
