using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.PublicSection
{
    public class ShoppingCartModel : PageModel
    {
        
        //public Dictionary<int, Product> AddedProducts; /*{ get; set; }*/
        public List<Product> OrderProducts;
        private StoreCatalog _storeCatalog;
        private ShoppingCartCatalog _shoppingCartCatalog;
        public Product Product { get; set; }
        public ShoppingCartModel(StoreCatalog repoStoreCatalog,ShoppingCartCatalog repoShoppingCartCatalog)
        {
             OrderProducts = new List<Product>();
            _storeCatalog = repoStoreCatalog;
            _shoppingCartCatalog = repoShoppingCartCatalog;
        }

        public IActionResult OnGet(int id, int storeid) //On StoreDetails, using asp-route I pass 2 different Ids, regarding each store and then receive them here.
        {
            Product = _storeCatalog.GetStore(storeid).Products[id]; //get the specific product, not matter which store
            _shoppingCartCatalog.AddProduct(Product); //Add the product to the list
            OrderProducts = _shoppingCartCatalog.GetAll(); //refresh the list
            return Page();
        }
    }
}
