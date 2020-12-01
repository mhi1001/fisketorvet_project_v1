using System.Collections.Generic;
using System.Linq;
using fisketorvet_project_v1.Helpers;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Services
{
    public class StoreCatalog
    {
        private string filePath = @".\Data\Stores.json";
        private Dictionary<int, Store> Stores { get; set; }
        private Dictionary<int, Product> Products { get; set; }

        public void AddProductStore(Product product)
        {
            //test
        }
        
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

        public void RemoveStore(int id)
        {
            Stores.Remove(id);
        }

        public Store GetStore(int id)
        {
            Stores = GetAllStores(); //Populate the dictionary
            foreach (Store st in Stores.Values)
            {
                if (st.Id == id)
                {
                    return st;
                }
            }
            return new Store();
        }

        public Store AutoIncrementId(Store s) //Method to automatically add all the ids
        {
            Stores = GetAllStores(); //
            // empty list that receives all the IDs
            List<int> Id = new List<int>();
            foreach (var store in Stores.Values)
            {
                Id.Add(store.Id);
            }

            if (Id.Count != 0)//if there are IDs, it will get the last value and add +1 
            {
                int maxId = Id.Max() + 1;
                s.Id = maxId;
            }
            else//If there are no IDs on the list, it will add automatically 1
            {
                s.Id = 1;
            }

            return s;

        }



    }
}
