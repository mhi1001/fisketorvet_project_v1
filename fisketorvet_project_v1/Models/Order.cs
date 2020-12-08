using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Pages;

namespace fisketorvet_project_v1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set;}
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }
    }
} 
