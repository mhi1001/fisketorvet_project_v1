using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages
{
    public class DeleteStore : PageModel
    {
        private StoreCatalog _storeCatalog;
        [BindProperty]
        public Store Store { set; get; }

        public DeleteStore(StoreCatalog repoStoreCatalog)
        {
            _storeCatalog = repoStoreCatalog;
        }
        public IActionResult OnGet(int id)
        {
            Store = _storeCatalog.GetStore(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _storeCatalog.RemoveStore(id);
            return Redirect("/AdminSection/StoreAdminPage");
        }
    }
}
