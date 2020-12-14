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
    public class EditUserModel : PageModel
    {
        private CustomerCatalog userCatalog;

        [BindProperty]
        public Customer Customer { set; get; }

        public EditUserModel(CustomerCatalog RepoCustCat)
        {
           userCatalog = RepoCustCat;
        }

        public void OnGet(int id)
        {
            Customer = userCatalog.GetCustomer(id);
        }
        public IActionResult OnPost(int id)
        {
            Customer.Id = userCatalog.GetCustomer(id).Id; //Returns an ID instead of the full object, so the ID stays the same but the changes are updated
            userCatalog.UpdateCustomer(Customer);
            return Redirect("/AdminSection/CustomerAdminPage");
        }
    }
}
