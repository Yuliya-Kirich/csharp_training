using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class AccountData
    {
        //Хранятся данные о пользователе (его логин и пароль)

        private string username;
        private string password;

       //Конструктор, позволяет конструировать объект в одну строчку
       //Конструктор позволяет быстро конструировать новые объекты
        public AccountData(string username, string password)
        {
            //в поле присваеиваем значение, которое передано, как параметр
            this.username = username;
            //в поле присваеиваем значение, которое передано, как параметр
            this.password = password;
         
        }

        //Для каждого из двух значений делаем свойство 
        //get, set позволяют менять значение свойств объекта, когда нам это необходимо
        public string Username
        {
            //Возвращает значение поля
            get
            {
                return username;
            }
            //Присваивает значение поля
            set
            {
                username = value;
            }
        }

        public string Password 
        {
            //Возвращает значение поля
            get
            {
                return password;
            }
            //Присваивает значение поля
            set
            {
                password = value;
            }
        }

    }
}
