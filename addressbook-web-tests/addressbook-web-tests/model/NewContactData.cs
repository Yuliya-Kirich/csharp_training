using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class NewContactData : IEquatable<NewContactData>, IComparable<NewContactData>
    {
        private string allPhones;
        private string address;
        private string allemails;



        //  private string firstname = "";
        //  private string lastname = "";

        /* public NewContactData(string firstname)
         {
             this.firstname = firstname;
         }
 */

        public NewContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
          /* 
            HomePhone = homePhone;
            MobilePhone = mobilePhone;
            WorkPhone = workPhone;
            AllPhones = allPhones;*/

            //this.firstname = firstname;
            //this.lastname = lastname;
        }

        public NewContactData(string v)
        {
           
          
        }

        public bool Equals(NewContactData other)
        {

            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            
            return Firstname == other.Firstname 
                && Lastname == other.Lastname;

            // return [Firstname == other.Firstname, Lastname == other.Lastname];
            // return Lastname == other.Lastname;
        }


        public override int GetHashCode()  //так как переопределяет стандартный метод определенный в базовом классе (то override)
        {
            

               return Firstname.GetHashCode() & Lastname.GetHashCode();
        }


        public override string ToString()
        {
            return "Firstname = " + Firstname + "  Lastname = " + Lastname;

        }

        public int CompareTo(NewContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            string oldfirstlast = Firstname + Lastname;
            string newfirstlast = other.Firstname + other.Lastname;
            return oldfirstlast.CompareTo(newfirstlast);
           // return Lastname.CompareTo(other.Lastname) ^ Firstname.CompareTo(other.Firstname); 
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }       
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
       // public string Address { get; set; }

          public string Address
          {
              get{
                  
                      return CleanUpAd(address);
                  
              }
              set
              {
                  address = value;
              }
          }


        public string AllPhones
        {
            get{
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }



        private string CleanUp(string phone)
        {
          if (phone == null || phone == "")
            {
                return "";
            }
            //  return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            return Regex.Replace(phone, "[ -()HMW:\r]", "") + "\r\n"; //регулярное выражение
        }


        private string CleanUpAd(string addr)
        {
            if (addr == null || addr == "")
            {
                return "";
            }
            //  return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            return Regex.Replace(addr, "[\r]", "");  //регулярное выражение
        }


        public string AllEmails
        {
            get
            {
                if (allemails != null)
                {
                    return allemails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allemails = value;
            }
        }

        private string CleanUpEmails(string emls)
        {
            if (emls == null || emls == "")
            {
                return "";
            }
            //  return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            return Regex.Replace(emls, "[ ()!#$%^&*|?/:\r,]", "") + "\r\n"; //регулярное выражение
        }


        /* public string Firstname
          {
              get
              {
                  return firstname;
              }
              set
              {
                  firstname = value;
              }
          }

          public string Lastname
          {
              get
              {
                  return lastname;
              }
              set
              {
                  lastname = value;
              }
          }
          */
    }
}
