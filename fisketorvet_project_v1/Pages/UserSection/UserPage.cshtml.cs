using System.Collections.Generic;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace fisketorvet_project_v1.Pages.UserSection
{
    public class UserPageModel : PageModel
    {
      
        private OrderCatalog _orderCatalog;
       
        public Dictionary<int, Order> Orders { get; set; }
        public Customer Customer { get; set; }

        public UserPageModel(OrderCatalog repoOrderCatalog)
        {
            _orderCatalog = repoOrderCatalog;
        }
        
        public IActionResult OnGet(int id)
        {
            Customer = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("cat"));
            Orders = _orderCatalog.MyOrders(Customer.Id);
            return Page();
        }

    }
}
