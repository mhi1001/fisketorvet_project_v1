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
           Store.Products.Add(Product.Id, Product);//idk how to make this shit work
                                                    //giving null because the dictionary itself is not initialized.
                                                    //I cant initialize it somewhere or else data will always get rewritten ? 
                                                    //Json is also confusing me about this, i dont know how to proceed to make it so
                                                    //I can add the products to this specific store (since the store model has a products dictionary) while
                                                    //at the same time saving, the products to an individual json file.......
                                                    //if i dont link it like this, how am i supposed to display all the products that are
                                                    //respective of that the store you pick ??????????????
                                                    //spent 2 hours on this and i still cant do it 
            
            return Redirect("Index");
        }
    }
}
