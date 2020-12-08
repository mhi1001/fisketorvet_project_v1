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
    public class DeleteCustomerModel : PageModel
    {
        private CustomerCatalog _customerCatalog;

        public DeleteCustomerModel(CustomerCatalog repoCustomerCatalog)
        {
            _customerCatalog = repoCustomerCatalog;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("SessionType") != "adminSession")
            {
                return Redirect("/Unauthorized");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _customerCatalog.RemoveCustomer(id);
            return Redirect("/AdminSection/CustomerAdminPage");
        }
    }
}
