using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("cat") != null || HttpContext.Session.GetString("SessionType") != null)
            {
                HttpContext.Session.Clear();
                return Redirect("/Index");
            }
            
            return Redirect("/Index");
        }
    }
    
}
