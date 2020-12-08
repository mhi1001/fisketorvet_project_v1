using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.AdminSection
{
    public class OrderAdminPageModel : PageModel
    {
        private OrderCatalog _orderCatalog;
        
        public Order Order { get; set; }
        public Dictionary<int, Order> Orders { get; set; }

        public OrderAdminPageModel(OrderCatalog repoOrderCatalog)
        {
            _orderCatalog = repoOrderCatalog;

        }
        public void OnGet()
        {
            Orders = _orderCatalog.GetAllOrders();
        }
    }
}
