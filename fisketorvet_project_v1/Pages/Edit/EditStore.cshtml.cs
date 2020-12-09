using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.Edit
{
    public class EditStoreModel : PageModel
    {
        private StoreCatalog _storeCatalog;

        [BindProperty]
        public Store Store { get; set; }

        public EditStoreModel(StoreCatalog repoStoreCatalog)
        {
            _storeCatalog = repoStoreCatalog;
        }

        public void OnGet(int id)
        {
            Store = _storeCatalog.GetStore(id);
        }

        public IActionResult OnPost(int id)
        {
            Store.Id = _storeCatalog.GetStore(id).Id; //Returns an ID instead of the full object, so the ID stays the same but the changes are updated
            _storeCatalog.UpdateStore(Store);
            return Redirect("/AdminSection/StoreAdminPage");
        }
    }
}
