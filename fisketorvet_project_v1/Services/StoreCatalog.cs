using System.Collections.Generic;
using fisketorvet_project_v1.Helpers;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Services
{
    public class StoreCatalog
    {
        private string filePath = @".\Data\Stores.json";
        private Dictionary<int, Store> Stores { get; set; }

        public Dictionary<int, Store> GetAllStores()
        {
            return JsonReader.ReadStoreJson(filePath);
        }

        public void AddStore(Store store)
        {
            Stores = GetAllStores(); //Populate it with existing stores.

            Stores.Add(store.Id, store);
            JsonWriter.WriteToStoresJson(Stores, filePath); //After adding the new one to the dictionary, writes it again to json
        }


    }
}
