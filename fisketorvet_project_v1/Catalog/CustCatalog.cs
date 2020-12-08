using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Pages;

namespace fisketorvet_project_v1.Catalog
{
    public class CustCatalog
    {
        Dictionary<int, Customer> clients=new Dictionary<int, Customer>();
        private Dictionary<int, Customer> customers { get; set; }

        public void AddCustomer(Customer c)
        {
            clients.Add(c.Id,c);
        }

        public void DeleteCustomer(Customer c)
        {
            clients.Remove(c.Id);
        }

        public void Update(Customer c)
        {
            
        }

        public Customer SearchCustomer(int id)
        {
            return new Customer();
        }
    }
}
