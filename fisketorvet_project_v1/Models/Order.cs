using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Pages;

namespace fisketorvet_project_v1.Models
{
    public class Order
    {
        public DateTime Date { get; set; }
        public Customer Customer { get; set;}
        public Dictionary<int, Product> Products { get; set; }
    }
} 
