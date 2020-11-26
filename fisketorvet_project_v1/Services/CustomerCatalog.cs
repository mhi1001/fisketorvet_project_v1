using System.Collections.Generic;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Services
{
    public class CustomerCatalog
    {
        private string filePath = @".\Data\Customers.json";
        private Dictionary<int, Customer> Customers { get; set; }

        public void AddCustomer(Customer c)
        {
            Customers.Add(c.Id,c);
        }

        public void RemoveCustomer(Customer c)
        {
            Customers.Remove(c.Id);
        }


    }
}
