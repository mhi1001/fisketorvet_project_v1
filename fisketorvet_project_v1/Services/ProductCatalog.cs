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
        public Product AutoIncrementId(Product p) //Method to automatically add all the ids
        {
            Products = GetAllProducts(); //
            // empty list that receives all the IDs
            List<int> id = new List<int>();
            foreach (Product prd in Products.Values)
            {
                id.Add(prd.Id);
            }

            if (id.Count != 0)//if there are IDs, it will get the last value and add +1 
            {
                int maxId = id.Max() + 1;
                p.Id = maxId;
            }
            else//If there are no IDs on the list, it will add automatically 1
            {
                p.Id = 1;
            }

            return p;

        }
        
    }
}
