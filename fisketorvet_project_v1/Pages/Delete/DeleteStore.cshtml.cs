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
    public class Index1Model : PageModel
    {
        public StoreCatalog storeCatalog { set; get; }
        [BindProperty]
        public Store store { set; get; }
        public IActionResult OnGet(int id)
        {
            store = storeCatalog.GetStore(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            storeCatalog.RemoveStore(id);
            return Redirect("ViewStores");
        }
    }
}
