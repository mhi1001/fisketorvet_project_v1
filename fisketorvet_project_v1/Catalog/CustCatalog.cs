using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Pages;

namespace fisketorvet_project_v1.Catalog
{
    public class CustCatalog
    {
        Dictionary<int, Customer> clients=new Dictionary<int, Customer>();

        public void AddCustomer(Customer c)
        {
            clients.Add(c.ID,c);
        }

        public void DeleteCustomer(Customer c)
        {
            clients.Remove(c.ID);
        }

        public void Update(Customer c)
        {
            
        }

        public Customer SearCustomer()
        {

        }
    }
}
