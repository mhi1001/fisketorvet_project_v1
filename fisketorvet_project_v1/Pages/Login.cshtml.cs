using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace fisketorvet_project_v1.Pages
{
    public class LoginModel : PageModel
    {
        private Dictionary<int, Customer> Customers { get; set; }
        private CustomerCatalog _customerCatalogRepo;
        [BindProperty]
        public Customer Customer { get; set; }

        public LoginModel(CustomerCatalog repoCustomerCatalog)
        {
            _customerCatalogRepo = repoCustomerCatalog;
        }

        public IActionResult OnPost()
        {
            return CheckLogin();
        }

        private IActionResult CheckLogin()
        {
            string password, username;
            username = Request.Form["Username"];
            password = Request.Form["Password"];

            bool userTry = _customerCatalogRepo.CheckPassword(username, password);
            if (userTry)
            {
                Customer = GetCustomerUsername(username);
                HttpContext.Session.SetString("cat",JsonConvert.SerializeObject(Customer));
                if (Customer.Admin)
                {
                    HttpContext.Session.SetString("SessionType","adminSession");
                    return RedirectToPage("/AdminSection/AdminPage");
                }
                else
                {
                    return RedirectToPage("/UserSection/UserPage");
                }
            }
            
            return Page();
        }

        private Customer GetCustomerUsername(string username)
        {
            Customers = _customerCatalogRepo.GetAllCustomers();
            foreach (Customer c in Customers.Values)
            {
                if (c.UserName == username)
                {
                    return c;
                    
                }
               
            }
            return new Customer();
        }
    }
}
