using System;
using System.ComponentModel.DataAnnotations;

namespace classes
{
    public class Customer
    {
        public int Id { get; private set; }


        public string Name { get; private set; }
        public string Address { get; private set; }

        [RegularExpression("^[0 - 9]{4}[ ]{0,1}[0-9]{3}[ ]{0,1}[0-9]{3}$")]
        public string PhoneNumber { get; private set; }

        [RegularExpression("[^@]+@[^\\.]+\\..+")]
        public string Email { get; private set; }

        public Customer(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Customer()
        {
        }


    }
}
