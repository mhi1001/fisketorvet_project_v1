using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Pages;

namespace fisketorvet_project_v1.Helpers
{
    public class JsonReader
    {
        public static Dictionary<int, Order> ReadOrderJson(string jsonFilePath)
        {
            string jsonString = File.ReadAllText(jsonFilePath); //Read the json file and set it to a string

            return JsonConvert.DeserializeObject<Dictionary<int, Order>>(jsonString); //deserializes into our dictionary
        }

        internal static Dictionary<int, SiteUser> ReadJson(string filePath)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<int, Customer> ReadCustomerJson(string jsonFilePath)
        {
            string jsonString = File.ReadAllText(jsonFilePath); //Read the json file and set it to a string

            return JsonConvert.DeserializeObject<Dictionary<int, Customer>>(jsonString); //deserializes into our dictionary
        }
        public static Dictionary<int, Product> ReadProductJson(string jsonFilePath)
        {
            string jsonString = File.ReadAllText(jsonFilePath); //Read the json file and set it to a string

            return JsonConvert.DeserializeObject<Dictionary<int, Product>>(jsonString); //deserializes into our dictionary
        }
        public static Dictionary<int, Store> ReadStoreJson(string jsonFilePath)
        {
            string jsonString = File.ReadAllText(jsonFilePath); //Read the json file and set it to a string

            return JsonConvert.DeserializeObject<Dictionary<int, Store>>(jsonString); //deserializes into our dictionary
        }
        public static Dictionary<int, SiteUser> ReadSiteUserJson(string jsonFilePath)
        {
            string jsonString = File.ReadAllText(jsonFilePath); //Read the json file and set it to a string

            return JsonConvert.DeserializeObject<Dictionary<int, SiteUser>>(jsonString); //deserializes into our dictionary
        }
    }
}
