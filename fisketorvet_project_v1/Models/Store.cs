using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fisketorvet_project_v1.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string TypeOfStore { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public Dictionary<int, Product> Products { get; set; }
    }
}
