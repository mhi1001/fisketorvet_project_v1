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
    public class RegisterPageModel : PageModel
    {
        private CustomerCatalog _customerCatalog;
        [BindProperty]
        public Customer Customer { get; set; }

        public RegisterPageModel(CustomerCatalog repoCustomerCatalog)
        {
            _customerCatalog = repoCustomerCatalog;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Customer.Admin = false; //Set default as false, so the registered users arent given admin
            _customerCatalog.AddCustomer(Customer); //Adding customer
            return Redirect("/Login");
        }
    }
}
