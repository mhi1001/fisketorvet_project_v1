using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.Delete
{
    public class DeleteProductModel : PageModel
    {
        private StoreCatalog _storeCatalog;

        public Product Product { get; set; }
        public DeleteProductModel(StoreCatalog repoStoreCatalog)
        {
            _storeCatalog = repoStoreCatalog;
        }
        
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("SessionType") != "adminSession")
            {
                return Redirect("/Unauthorized");
            }

            return Page();
        }

        public IActionResult OnPost(int storeid, int productid)
        {
            _storeCatalog.RemoveProductFromStore(storeid, productid);

            return Redirect($"/AdminSection/ManageProducts?id={storeid}");
            
        }
    }
}
