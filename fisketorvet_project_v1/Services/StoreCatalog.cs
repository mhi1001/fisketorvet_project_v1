using System.Collections.Generic;
using System.Linq;
using fisketorvet_project_v1.Helpers;
using fisketorvet_project_v1.Models;
using Newtonsoft.Json;


namespace fisketorvet_project_v1.Services
{
    public class StoreCatalog
    {
        private string filePath = @".\Data\Stores.json";

        private Dictionary<int, Store> Stores { get; set; }




        public Dictionary<int, Store> GetAllStores()
        {
            return JsonReader<int, Store>.ReadJson(filePath);
        }


        public void UpdateStore(Store store)
        {
            Stores = GetAllStores();
            Store foundStore = Stores[store.Id];
            foundStore.Id = store.Id;
            foundStore.Name = store.Name;
            foundStore.Location = store.Location;
            foundStore.ImagePath = store.ImagePath;
            foundStore.TypeOfStore = store.TypeOfStore;
            foundStore.Products = store.Products;


            JsonWriter<int, Store>.WriteToJson(Stores, filePath);
        }

        public void RemoveStore(int id)
        {
            Stores = GetAllStores();
            Stores.Remove(id);

            JsonWriter<int, Store>.WriteToJson(Stores, filePath);
        }

        public void AddStore(Store store)
        {
            
            Stores = GetAllStores(); //Populate it with existing stores.
            store.Id = GenerateStoreId(Stores);
            Stores.Add(store.Id, store);
            JsonWriter<int, Store>.WriteToJson(Stores, filePath); //After adding the new one to the dictionary, writes it again to json
        }

        public Store GetStore(int id) //Faster way to find store
        {
            Stores = GetAllStores(); //Populate the dictionary
            Store foundStore = Stores[id];
            return foundStore;
        }

        private int GenerateProductId(Dictionary<int, Product> oldProducts)
        {
            List<int> Ids = new List<int>();
            foreach (var v in oldProducts) //receives the existing products and loops through them
            {
                Ids.Add(v.Value.Id); //for eachh product add the ID of that own product to a list
            }
            if (Ids.Count != 0)
            {
                return Ids.Max() + 1;
            }
            else
                return 1; //pretty much if its not zero it gets the last value (highest) and adds plus 1, if its zero just gives one.

        }
        private int GenerateStoreId(Dictionary<int, Store> oldStores)
        {
            List<int> Ids = new List<int>();
            foreach (var s in oldStores) 
            {
                Ids.Add(s.Value.Id); 
            }
            if (Ids.Count != 0)
            {
                return Ids.Max() + 1;
            }
            else
                return 1; 

        }

        public void AddProductToStore(Product product, int id)
        {
            Dictionary<int, Product> oldProducts = GetStore(id).Products; //Initialize the dictionary by getting the respective's store
                                                                          // products ((PREVENTS NULL EXCEPTION)

            product.Id = GenerateProductId(oldProducts); //gets the ID from the generator method

            oldProducts.Add(product.Id, product); //and then adds the product to existing product dictionary

            Stores = GetAllStores(); //We populate the stores one

            Stores[id].Products = oldProducts; //we add the newly added products to the specific store that we edit

            JsonWriter<int, Store>.WriteToJson(Stores, filePath); //and then write the store to json
        }
    }
}
