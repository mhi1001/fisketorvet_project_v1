using System.Collections.Generic;
using System.Linq;
using fisketorvet_project_v1.Helpers;
using fisketorvet_project_v1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace fisketorvet_project_v1.Services
{
    public class CustomerCatalog
    {
        private string filePath = @".\Data\Customers.json";
        private Dictionary<int, Customer> Customers { get; set; }

        public Dictionary<int, Customer> GetAllCustomers()
        {
            return JsonReader<int, Customer>.ReadJson(filePath);
        }

        public void UpdateCustomer(Customer customer)
        {
            Dictionary<int, Customer> customers = GetAllCustomers();
            Customer foundCustomer = customers[customer.Id];
            foundCustomer.Name = customer.Name;
            foundCustomer.Address = customer.Address;
            foundCustomer.Email = customer.Email;
            foundCustomer.PhoneNumber = customer.PhoneNumber;
            foundCustomer.Password = customer.Password;
            foundCustomer.Admin = GetCustomer(customer.Id).Admin;
            JsonWriter<int, Customer>.WriteToJson(customers, filePath);

        }

        public void AddCustomer(Customer customer)
        {
            Dictionary<int, Customer> customers = GetAllCustomers(); //Populate it 
            customer.Id = GenerateCustomerId(customers);
            customer.Password = PasswordHash(customer.UserName, customer.Password);
            customers.Add(customer.Id, customer);
            JsonWriter<int, Customer>.WriteToJson(customers, filePath); //After adding the new one to the dictionary, writes it again to json
        }

        public void RemoveCustomer(int id)
        {
            Customers = GetAllCustomers();
            Customers.Remove(id);
            JsonWriter<int, Customer>.WriteToJson(Customers,filePath);
        }

        public Customer GetCustomer(int id)
        {
            Customers = GetAllCustomers(); //Populate the dictionary
            Customer foundCustomer = Customers[id];
            return foundCustomer;
        }


        public bool CheckPassword(string username, string password)
        {
            bool valid = false;
            Customers = GetAllCustomers();

            foreach (Customer customer in Customers.Values)
            {
                if (customer.UserName == username)
                {
                    string jsonPassword = customer.Password;
                    PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
                    var verificationResult = passwordHasher.VerifyHashedPassword(username, jsonPassword, password);
                    if (verificationResult == PasswordVerificationResult.Success)
                        valid = true;
                    else
                        valid = false;
                    return valid;
                }
            }

            return valid;
        }
        public string PasswordHash(string username, string password)
        {
            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
            string hashedPassword = passwordHasher.HashPassword(username, password);
            return hashedPassword;
        }

        private int GenerateCustomerId(Dictionary<int, Customer> oldCustomers)
        {
            List<int> Ids = new List<int>();
  
            foreach (var s in oldCustomers) 
            {
                Ids.Add(s.Value.Id); 
            }
            if (Ids.Count != 0)
            {
                return Ids.Max() + 1;
            }
            else
                return 1; 

        }


    }
}
