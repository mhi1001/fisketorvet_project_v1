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
    public class ViewStoresModel : PageModel
    {
        private StoreCatalog _storeCatalog;
        public Dictionary<int, Store> Stores { get; set; }
        public ViewStoresModel(StoreCatalog repoStoreCatalog )
        {
            _storeCatalog = repoStoreCatalog;
        }
        public void OnGet()
        {
            Stores = _storeCatalog.GetAllStores();
        }
    }
}
