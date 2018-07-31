using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNewContactTests
{
    //класс содержит совокупность информации о новом контакте

    class AccountDataContact
    {
        private string username;
        private string password;

        //конструктор новых объектов, чтобы в одну строчку
        public AccountDataContact(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        //для каждого значения делаем свойство
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


    }
   
}
