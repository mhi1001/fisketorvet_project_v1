using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.AdminSection 
{
    public class CreateStoreAdminPageModel : PageModel
    {
        private StoreCatalog _storeCatalog;
        [BindProperty]
        public Store Store { get; set; }

        public CreateStoreAdminPageModel(StoreCatalog repoStoreCatalog )
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

        public IActionResult OnPost()
        {
             
            _storeCatalog.AddStore(Store); //Add the store to the catalog

            return Redirect("/AdminSection/StoreAdminPage");
        }
    }
}
