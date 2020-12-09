using System.Collections.Generic;
using System.Linq;
using fisketorvet_project_v1.Helpers;
using fisketorvet_project_v1.Models;
using Microsoft.AspNetCore.Components;
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

        public void AddCustomer(Customer customer)
        {
            Customers = GetAllCustomers(); //Populate it 
            customer.Id = GenerateCustomerId(Customers);
            Customers.Add(customer.Id, customer);
            JsonWriter<int, Customer>.WriteToJson(Customers, filePath); //After adding the new one to the dictionary, writes it again to json
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

        public Customer SiteAuth(string username, string password)//Method to authenticate users
        {
            Customers = GetAllCustomers(); //Populate the Dictionary with all the existing users so we can test credentials
            //Cant figure out how to make it so when its true, it will also return Admin = true when passing to the controller class
            //So im going to make it return a integer and do a switchcase on the Login onpost method.
            foreach (Customer user in Customers.Values)
            {
                if (user.UserName.Equals(username) && user.Password.Equals(password))
                {
                    return user; //If the user exists and is admin from the Json it will return number 0;
                                    // if the user exists but isn't admin, it will return number 1;
                }
            }

            return null; //in the end if the user is incorrect or something it will return 2 
        }

        //public bool SiteAuth(SiteUser user)//Method to authenticate users
        //{
        //    SiteUsers = GetAllSiteUsers(); //Populate the Dictionary with all the existing users so we can test credentials

        //    return SiteUsers.ContainsValue(user);
        //}
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
