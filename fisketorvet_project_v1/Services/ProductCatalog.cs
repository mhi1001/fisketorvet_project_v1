using System.Collections.Generic;
using System.Linq;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Helpers;

namespace fisketorvet_project_v1.Services
{
    public class ProductCatalog
    {
        private string filePath = @".\Data\Products.json";

        private Dictionary<int, Product> Products { get; set; }
        public StoreCatalog StoreCatalog;

        public Store AddProductToStore(Store store, Product product)
        {
            store.Products.Add(product.Id, product);
            return store;
        }

        public Dictionary<int, Product> GetAllProducts()
        {
            return JsonReader.ReadProductJson(filePath);
        }

        public void AddProduct(Product product)
        {
            Products = GetAllProducts(); //Populate it with existing stores.

            Products.Add(product.Id, product);
            JsonWriter.WriteToProductsJson(Products, filePath); //After adding the new one to the dictionary, writes it again to json
        }
        public Product GetProduct(int id)
        {
            Products = GetAllProducts(); //Populate the dictionary
            foreach (Product prd in Products.Values)
            {
                if (prd.Id == id)
                {
                    return prd;
                }
            }
            return new Product();
        }

    }
}
