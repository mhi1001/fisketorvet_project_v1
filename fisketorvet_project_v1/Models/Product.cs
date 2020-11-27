using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum ProductType
{
    Food,
    Beverages,
    Clothing,
    Medicine,
    Toys,
    Books,

}

namespace fisketorvet_project_v1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public string ProductName { get; set; }
        public string Dimensions { get; set; }
        
    }
}
