﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Catalog
{
    public class OrderCatalog
    {
        private string filePath = @".\Data\Orders.json";
        private Dictionary<int, Order> Orders { get; set; }

    }
}
