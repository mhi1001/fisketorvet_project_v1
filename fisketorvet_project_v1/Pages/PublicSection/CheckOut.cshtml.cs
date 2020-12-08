using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace fisketorvet_project_v1.Pages.PublicSection
{
    public class CheckOutModel : PageModel
    {
        private ShoppingCartCatalog _shoppingCartCatalog;
        private OrderCatalog _orderCatalog;

        public List<Product> OrderProducts { get; set; }
        public Customer Customer { get; set; }

        public Order Order { get; set; }

        public CheckOutModel(ShoppingCartCatalog repoShoppingCartCatalog, OrderCatalog repoOrderCatalog)
        {
            _shoppingCartCatalog = repoShoppingCartCatalog;
            _orderCatalog = repoOrderCatalog;
        }

        public IActionResult OnGet()
        {
            Customer = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("cat")); //get the customer based on the station
            OrderProducts = _shoppingCartCatalog.GetAll();
            if (OrderProducts.Count <= 0)
            {
                return Redirect("ShoppingCart");
            }
            Order order = new Order();
            order.Customer = Customer;
            order.Products = OrderProducts;
            order.Date = DateTime.Now;
            order.TotalPrice = OrderProducts.Sum(product => product.Price);
            _orderCatalog.AddOrder(order);

            
            return Page();
        }

        public IActionResult OnPostResetCart()
        {
            OrderProducts = _shoppingCartCatalog.GetAll();
            OrderProducts.Clear();
            return Redirect("/Index");
        }
    }
}
