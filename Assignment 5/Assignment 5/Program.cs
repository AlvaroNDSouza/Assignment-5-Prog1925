using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    internal class Program
    {
        static List <Customer> customers = new List <Customer> ();
        static void Main(string[] args)
        {
            /* Project file name : Assignment_5
             * * Purpose of program : create a C# console program for an online clothing store which can create, edit, and display customer
             * information.
             * *
             * * Revision History:
             * * Alvaro de Souza and Hrituj Sharma, created: 2023.04.5*/

            Console.WriteLine("Welcome to PROG1925");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Please Select an option:\n" +
                   "1 - Add new Customer\n" +
                   "2 - Edit Existing Customer\n" +
                   "3 - Display Customer\n" +
                   "4 - Exit");

                int input;

                while(!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Invalid Input. Please Try again!");
                }
                switch (input)
                {
                    case 1:
                        AddNewCustomer();
                        break;
                    case 2:
                        EditCustomer();
                        break;
                    case 3:
                        DisplayCustomer();
                        break;
                    case 4:
                        Console.WriteLine("Existing Program...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please Try Again.");
                        break;
                }
            }
        }
        public static void AddNewCustomer()
        {
            if(customers.Count >= 30)
            {
                Console.WriteLine("Customer Limit Reached!");
                return;
            }
            Console.WriteLine("Enter Customer E-mail:");
            string email = Console.ReadLine();
            if (!IsEmailValid(email))
            {
                Console.WriteLine("Invalid Email Format.");
                return;
            }
            if (CustomerExists(email))
            {
                Console.WriteLine("Customer record already exists");
                return;
            }

            Console.WriteLine("Please Enter the Customer Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Please Enter the Customer Age");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 13 || age > 100)
            {
                Console.WriteLine("Invalid age. Please try again.");
            }
            int id = GenerateId();
            customers.Add(new Customer(id, email, name, age));
            Console.WriteLine($"The customer was Succesfully added to our data base. Customer ID: {id}");
        }
        public static void EditCustomer()
        {
            Console.WriteLine("Please enter the ID of the customer you wish to edit :");
            int InputId = int.Parse(Console.ReadLine());

            Customer customerToEdit = GetCustomerById(InputId);

            if (customerToEdit == null)
            {
                Console.WriteLine("Customer Not Found");
                return;
            }
            customerToEdit.DisplayCustomerInformation();

            Console.WriteLine("Please select the information you want to edit:\n" +
                "1 - Email\n" +
                "2 - Name\n" +
                "3 - Age");

            int input = int.Parse(Console.ReadLine());
            switch(input)
            {
                case 1:
                    Console.WriteLine("Please Enter the new email:");
                    string newEmail = Console.ReadLine();
                    if (!IsEmailValid(newEmail))
                    {
                        Console.WriteLine("Invalid Email Format.");
                        return;
                    }
                    customerToEdit.EditCustomerInformation("email", newEmail);
                    break;
                case 2:
                    Console.WriteLine("Please Enter the new Name:");
                    string newName = Console.ReadLine();
                    customerToEdit.EditCustomerInformation("name",newName);
                    break;
                case 3:
                    Console.WriteLine("Please enter the new Age:");
                    int newAge = int.Parse(Console.ReadLine());
                    customerToEdit.EditCustomerInformation("age", newAge.ToString());
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please Try Again.");
                    break;
            }
            customerToEdit.DisplayCustomerInformation();
        }
        public static void DisplayCustomer()
        {
            Console.WriteLine("Enter the Customer ID:");
            int inputId = int.Parse(Console.ReadLine());

            Customer customer = GetCustomerById(inputId);
            if (customer != null)
            {
                Console.WriteLine($"ID: {customer.Id}");
                Console.WriteLine($"Name: {customer.Name}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Email: {customer.Age}");
            }
            else
            {
                Console.WriteLine("Customer Not found.");
            }
        }
        public static bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool CustomerExists(string email)
        {
            foreach (Customer customer in customers) 
            { 
                if (customer.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public static int GenerateId()
        {
            Random rand = new Random();
            int id;
            id = rand.Next(0000,9999);
            return id;
        }
        public static Customer GetCustomerById(int id)
        {
            foreach(Customer customer in customers)
            {
                if(customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }
       
    }
}
