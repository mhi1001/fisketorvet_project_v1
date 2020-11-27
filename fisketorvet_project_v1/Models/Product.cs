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
        public string Dimensions { get; set; } //Dimensions can be colour, size, weight, quantity, etc, I just dont know if we
                                                //should implement all these as variables or leave it all in dimensions
        
    }
}
