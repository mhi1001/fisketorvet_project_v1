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
    public class AddProduct2StoreModel : PageModel
    {
        private StoreCatalog _storeCatalog;
        private ProductCatalog _productCatalog;

        [BindProperty]
        public Product Product { get; set; }
        public Store Store { get; set; }


        public AddProduct2StoreModel(StoreCatalog repoStoreCatalog)
        {
            _storeCatalog = repoStoreCatalog;
        }
        public void OnGet()
        {



        }

        public IActionResult OnPost(int id)
        {
            _storeCatalog.AddProductToStore(Product, id);
            Store = _storeCatalog.GetStore(id);
            return RedirectToPage("ManageProducts", new { id = Store.Id });
        }
    }
}
