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
    public class CustomerAdminPageModel : PageModel
    {
        private CustomerCatalog _customerCatalog;
        
        public Dictionary<int, Customer> Customers { get; set; }

        public CustomerAdminPageModel(CustomerCatalog repoCustomerCatalog)
        {
            _customerCatalog = repoCustomerCatalog;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("SessionType") != "adminSession")
            {
                return Redirect("/Unauthorized");
            }

           
            Customers = _customerCatalog.GetAllCustomers();
            return Page();
        }
    }
}
