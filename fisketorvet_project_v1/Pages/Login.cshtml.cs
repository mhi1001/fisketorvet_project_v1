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
        private CustomerCatalog _custCatalogRepo;
        [BindProperty]
        public Customer SiteUser { get; set; }

        public LoginModel(CustomerCatalog repoCustCatalog)
        {
            _custCatalogRepo = repoCustCatalog;
        }

        public void OnGet()
        { 
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                if (_custCatalogRepo.SiteAuth(SiteUser.UserName, SiteUser.Password) != null)
                {
                    Customer s = _custCatalogRepo.SiteAuth(SiteUser.UserName, SiteUser.Password);
                    HttpContext.Session.SetString("cat",JsonConvert.SerializeObject(s));

                    if (s.Admin)
                    {
                        HttpContext.Session.SetString("SessionType","adminSession");
                        return RedirectToPage("/AdminSection/AdminPage");

                    }

                    else
                    {
                        return RedirectToPage("/UserSection/UserPage");
                    }
                }
            }
           return RedirectToPage("/Index");
        }
    }
}
