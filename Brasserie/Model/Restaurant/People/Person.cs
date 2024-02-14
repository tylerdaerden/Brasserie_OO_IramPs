using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.People
{
    //#nullable disable

    public class Person
    {
        private int _id { get; set; }
        private string _lastname { get; set; }
        private string _firstname { get; set; }
        private bool _gender { get; set; }
        private string _email { get; set; }
        private string _mobilePhoneNumber { get; set; }

        public int MyProperty { get; set; }


        public Person(int id , string lastName , string firstName="prenom" , bool gender=true , string email="" ,string mobilePhoneNumber="" )
        {
            _id = id;
            _lastname = lastName;
            _firstname = firstName;
            _gender = gender;
            _email = email;
            _mobilePhoneNumber = mobilePhoneNumber;

        }

        public Person() { }



    }


}
