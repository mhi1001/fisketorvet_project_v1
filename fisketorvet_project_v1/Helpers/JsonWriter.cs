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
    public class JsonWriter<K, V>
    {
        public static void WriteToJson(Dictionary<K, V> items, string jsonFileName)
        {
            string output = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFileName, output);
        }
    }
}
