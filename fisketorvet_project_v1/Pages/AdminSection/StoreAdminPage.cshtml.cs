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
    public class StoreAdminPageModel : PageModel
    {
        private StoreCatalog _storeCatalog;
        public Dictionary<int, Store> Stores { get; set; }

        public StoreAdminPageModel(StoreCatalog storeCatalog)
        {
            _storeCatalog = storeCatalog;
             Stores = _storeCatalog.GetAllStores();
        }
        public void OnGet()
        {

        }

        public IActionResult OnPostCreateNewStore()
        {
            return Redirect("/Create/CreateStoreAdminPage");
        }
    }
}
