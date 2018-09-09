using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class NewContactData : IEquatable<NewContactData>
    {

        private string firstname = "";
        private string lastname = "";

        public NewContactData(string firstname)
        {
            this.firstname = firstname;
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


            return Firstname == other.Firstname && Lastname == other.Lastname;

            // return [Firstname == other.Firstname, Lastname == other.Lastname];
            // return Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            
            return Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }

        public NewContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Firstname
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

       
    }
}
