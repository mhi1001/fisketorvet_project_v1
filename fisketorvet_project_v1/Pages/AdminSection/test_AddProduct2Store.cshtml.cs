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
    public class test_AddProduct2StoreModel : PageModel
    {
        private StoreCatalog _storeCatalog;
        private ProductCatalog _productCatalog;

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public Store Store { get; set; }


        public test_AddProduct2StoreModel(StoreCatalog repoStoreCatalog, ProductCatalog repoProductCatalog)
        {
            _storeCatalog = repoStoreCatalog;
            _productCatalog = repoProductCatalog;
            
            
        }
        public void OnGet()
        {
            
            Store = _storeCatalog.GetStore(1); //Get Zara Store for testing to add Products. Planning to make it dynamic soon
            
           }

        public IActionResult OnPost()
        {
            
            _productCatalog.AutoIncrementId(Product); //give the random generated ID to the Product
           // Store.Products = _storeCatalog.AddProductToStore(Product);//
           Store.Products = new Dictionary<int, Product>();
           Store.Products.Add(Product.Id, Product);
           //_storeCatalog.AddStore(Store);
           _storeCatalog.UpdateStore(Store);
           return Redirect("Index");
        }
    }
}
