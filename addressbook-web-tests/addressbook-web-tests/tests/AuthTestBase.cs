using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
   public class AuthTestBase : TestBase
    {
        [SetUp]
        public void /*SetupTest()*/ SetupLogin()
        {
            
            app.Auth.Login(new AccountData("admin", "secret")); // на 2 уровне - выполняется логин

           
        }
      
    }
}
