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
            Store = new Store();
            
        }
        public void OnGet()
        {
            
             //Get Zara Store for testing to add Products. Planning to make it dynamic soon
            
           }

        public IActionResult OnPost()
        {
             //give the random generated ID to the Product
           // Store.Products = _storeCatalog.AddProductToStore(Product);//
           //Store.Products = new Dictionary<int, Product>();
           //Store.Products.Add(Product.Id, Product);
           //Product p = new Product(){Id=1, Dimensions = "L",  ImageName = "tshirt1.jpg", ProductName = "Tshirt", ProductType = Product.ProductType = ProductType.Food};
           //Store.Products = new Dictionary<int, Product>().Add(p.Id, p);
           //_storeCatalog.AddStore(Store);
           Store = _storeCatalog.GetStore(1);

           _storeCatalog.AutoIncrementProductId(Product);
         //  _productCatalog.AutoIncrementId(Product);

           Store = _productCatalog.AddProductToStore(Store, Product);

            //_storeCatalog.AddStore(Store);
            _storeCatalog.UpdateStore(Store);

           return Redirect("AdminPage");
        }
    }
}
