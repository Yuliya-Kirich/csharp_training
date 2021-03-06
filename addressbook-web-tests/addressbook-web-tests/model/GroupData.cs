﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    // Класс содержит информацию об имене
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
       // private string name;  //поле можно убрать, оно будет создаваться автоматически (если name{get; set;})
        //Добавлено свойство с дефолтным (пустым) значением.
        //В конструкторе, теперь, это значение передавать не надо. По умолчанию туда будет помещена пустая строка.
      //  private string header = ""; поле можно убрать, оно будет создаваться автоматически(если name{ get; set; })
        //private string footer = ""; поле можно убрать, оно будет создаваться автоматически(если name{ get; set; })

        public GroupData(/*string name*/) //для xml конструктор, который не принимает никаких параметров
        {
            //this.name = name; //заменим присваивание поля в присваивание в свойство
           // Name = name;
        }

        public GroupData(string name) 
        {
            //this.name = name; //заменим присваивание поля в присваивание в свойство
             Name = name;
        }

        public bool Equals(GroupData other)
        {

            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // return Name.Equals(other.Name);
             //return Name.Equals(other.Name,StringComparison.OrdinalIgnoreCase); // сравнивать без учета регистра
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            //return 0;
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nheader= " + Header + "\nfooter=" + Footer;

        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }

        /* public string Name
         {
             get
             {
                 return name;

             }
             set
             {
                 name = value;
             }
         }*/

        //Если нужно поменять дополнительное, не обязательное значение, то используется свойство Header (типа string)
        /* public string Header
         {
             //Передает значение поля
             get
             {
                 return header;
             }
             //Возвращает значение поля
             set
             {
                 header = value;
             }
         }

         public string Footer
         {
             get
             {
                 return footer;
             }
             set
             {
                 footer = value;
             }
         }
         */
    }
}
