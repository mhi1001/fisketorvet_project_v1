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
    public class ManageProductsModel : PageModel
    {
        private StoreCatalog _storeCatalog;
        public Store Store { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public ManageProductsModel(StoreCatalog repoStoreCatalog)
        {
            _storeCatalog = repoStoreCatalog;
        }
        public void OnGet(int id)
        {
           
            Store = _storeCatalog.GetStore(id);
            Products = _storeCatalog.GetStore(id).Products;
            

        }

        
    }
}
