using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.PublicSection
{
    public class ShoppingCartModel : PageModel
    {
        
        //public Dictionary<int, Product> AddedProducts; /*{ get; set; }*/
        public List<Product> OrderProducts;
        private int _storeIdentification; //Variable to store which store is it, dont know if its needed yet
        private StoreCatalog _storeCatalog;
        
        public Product Product { get; set; }
        public ShoppingCartCatalog _ShoppingCartCatalog { get; } //To get access to the methods, in the VIEW page
       
        public ShoppingCartModel(StoreCatalog repoStoreCatalog,ShoppingCartCatalog repoShoppingCartCatalog)
        {
             OrderProducts = new List<Product>();
            _storeCatalog = repoStoreCatalog;
            _ShoppingCartCatalog = repoShoppingCartCatalog;
        }

        public IActionResult OnGet(int id, int storeid) //On StoreDetails, using asp-route I pass 2 different Ids, regarding each store and then receive them here.
        {
            if (HttpContext.Session.GetString("cat") == null)
            {
                return Redirect("/Login");
            }
            _storeIdentification = storeid;//Assigns the store identification
            Product = _storeCatalog.GetStore(storeid).Products[id]; //get the specific product, from the specific store(storeid)
            _ShoppingCartCatalog.AddProduct(Product); //Add the product to the list
            OrderProducts = _ShoppingCartCatalog.GetAll(); //refresh the list
            return Page();
        }

        public IActionResult OnPostDeleteProduct(int id) //Using page-handle, removes the selected item
        {
            _ShoppingCartCatalog.RemoveProduct(id);
            OrderProducts = _ShoppingCartCatalog.GetAll();

            return Page();
        }
    }
}
