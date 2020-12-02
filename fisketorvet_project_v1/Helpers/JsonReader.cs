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
    public class JsonReader<K, V>
    {
        public static Dictionary<K, V> ReadJson(string jsonFileName)
        {
            string jsonString = File.ReadAllText(jsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<K, V>>(jsonString);
        }


    }
}
