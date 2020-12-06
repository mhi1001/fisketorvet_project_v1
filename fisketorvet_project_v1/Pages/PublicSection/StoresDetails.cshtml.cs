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
    public class StoresDetailsModel : PageModel
    {
        private StoreCatalog _storeCatalog;   //
        public Store Store { get; set; }
        public Dictionary<int, Product> StoreProducts { get; set; }

        public StoresDetailsModel(StoreCatalog repoStoreCatalog)
        {
            _storeCatalog = repoStoreCatalog;
        }
        public IActionResult OnGet(int id)
        {
            Store = _storeCatalog.GetStore(id);
            StoreProducts = _storeCatalog.GetStore(id).Products;

            return Page();
        }

    }
}
