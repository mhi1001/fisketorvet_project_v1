using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Catalog
{
    public class StoreCatalog
    {
        private string filePath = @".\Data\Stores.json";
        private Dictionary<int, Store> Stores { get; set; }
    }
}
