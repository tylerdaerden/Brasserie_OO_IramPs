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
        private int _id;
        private string _lastname;
        private string _firstname;
        private bool _gender;
        private string _email;
        private string _mobilePhoneNumber;

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
