using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Pages;

namespace fisketorvet_project_v1.Catalog
{
    public class CustomerCatalog
    {
        private string filePath = @".\Data\Customers.json";
        private Dictionary<int, Customer> Customers { get; set; }


    }
}
