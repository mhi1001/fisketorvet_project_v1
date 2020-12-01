using System.Collections.Generic;
using fisketorvet_project_v1.Helpers;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Services
{
    public class CustomerCatalog
    {
        private string filePath = @".\Data\Customers.json";
        private Dictionary<int, Customer> Customers { get; set; }

        public Dictionary<int, Customer> GetAllCustomers()
        {
            return JsonReader.ReadCustomerJson(filePath);
        }

        public void AddCustomer(Customer c)
        {
            Customers.Add(c.Id,c);
        }

        public void RemoveCustomer(int id)
        {
            Customers.Remove(id);
        }

        public Customer GetStore(int id)
        {
            Customers = GetAllCustomers(); //Populate the dictionary
            foreach (Customer c in Customers.Values)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return new Customer();
        }

    }
}
