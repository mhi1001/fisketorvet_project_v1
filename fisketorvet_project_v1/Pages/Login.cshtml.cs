using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages
{
    public class LoginModel : PageModel
    {
        private SiteUserCatalog _siteUserRepo;
        [BindProperty]
        public SiteUser SiteUser { get; set; }

        public LoginModel(SiteUserCatalog repoSiteUserCatalog)
        {
            _siteUserRepo = repoSiteUserCatalog;
        }

        public void OnGet()
        {
           
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                switch (_siteUserRepo.SiteAuth(SiteUser.UserName, SiteUser.Password))
                {
                    case 0:
                        return RedirectToPage("AdminSection/AdminPage");


                    case 1:
                        return RedirectToPage("UserSection/UserPage");
                    //case 2:if()
                }
            }
            return Redirect("/Index");
        }
    }
}
