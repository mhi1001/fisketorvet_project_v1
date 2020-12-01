using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.Delete
{
    public class DeleteCustomerModel : PageModel
    {
        public CustomerCatalog CustomerCatalog { set; get; }

        [BindProperty]
        public Customer Customer { set; get; }
        public IActionResult OnGet(int id)
        {
            Customer = CustomerCatalog.GetStore(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            CustomerCatalog.RemoveCustomer(id);
            return Redirect("CustomerAdminPage");
        }
    }
}
