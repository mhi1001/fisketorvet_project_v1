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
        public List<Product> AddedProducts;
        private StoreCatalog _storeCatalog;
        private ShoppingCartCatalog _shoppingCartCatalog;
        public Product Product { get; set; }
        public ShoppingCartModel(StoreCatalog repoStoreCatalog,ShoppingCartCatalog repoShoppingCartCatalog)
        {
            AddedProducts = new List<Product>();
            _storeCatalog = repoStoreCatalog;
            _shoppingCartCatalog = repoShoppingCartCatalog;
        }

        public void OnGet(int id,)
        {Product product = _storeCatalog()
        }
    }
}
