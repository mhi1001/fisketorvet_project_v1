using System.Collections.Generic;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Services
{
    public class OrderCatalog
    {
        private string filePath = @".\Data\Orders.json";
        private Dictionary<int, Order> Orders { get; set; }

    }
}
