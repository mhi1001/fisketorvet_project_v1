using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Pages;
using Newtonsoft.Json;

namespace fisketorvet_project_v1.Helpers
{
    public class JsonWriter
    {
        public static void WriteToCustomersJson(Dictionary<int, Customer> customers, string jSonFilePath)
        {
            string output = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(jSonFilePath, output);
        }

        public static void WriteToOrdersJson(Dictionary<int, Order> orders, string jSonFilePath)
        {
            string output = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(jSonFilePath, output);
        }
        public static void WriteToProductsJson(Dictionary<int, Product> products, string jSonFilePath)
        {
            string output = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(jSonFilePath, output);
        }
        public static void WriteToStoresJson(Dictionary<int, Store> stores, string jSonFilePath)
        {
            string output = JsonConvert.SerializeObject(stores, Formatting.Indented);
            File.WriteAllText(jSonFilePath, output);
        }
    }
}
