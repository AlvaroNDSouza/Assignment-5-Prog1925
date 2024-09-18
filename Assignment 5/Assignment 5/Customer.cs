using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    internal class Customer
    {
        public int Id;
        public string Email;
        public string Name;
        public int Age;
        public Customer(int Id, string Email, string Name, int Age)
        {
            this.Id = Id;
            this.Email = Email;
            this.Name = Name;
            this.Age = Age;
        }
        public Customer()
        {
            Console.WriteLine("This is the default constructor");
            //Default
        }
        public void EditCustomerInformation(string field, string value)
        {
            switch(field.ToLower())
            {
                case "email":
                    Email = value;
                    break;
                case "name":
                    Name = value;
                    break;
                case "age":
                    Age = int.Parse(value);
                    break;
                default:
                    Console.WriteLine("Invalid Field.");
                    break;
            }
        }
        public void DisplayCustomerInformation()
        {
            Console.WriteLine($"ID:{Id}\n Email: {Email}\n Name: {Name}\n Age: {Age}");
        }
    }
}
