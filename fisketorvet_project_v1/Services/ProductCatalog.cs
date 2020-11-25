using System.Collections.Generic;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Services
{
    public class ProductCatalog
    {
        private string filePath = @".\Data\Products.json";
        private Dictionary<int, Product> Products { get; set; }
    }
}
