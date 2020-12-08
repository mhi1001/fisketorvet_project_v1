using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.AdminSection
{
    public class AdminPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("SessionType") != "adminSession")
            {
                return Redirect("/Unauthorized");
            }

            return Page();
        }

        public IActionResult OnPostManageStoreAdmin()
        {
            return Redirect("StoreAdminPage");
        }
        public IActionResult OnPostManageCustomerAdmin()
        {
            return Redirect("CustomerAdminPage");
        }
        public IActionResult OnPostManageOrderAdmin()
        {
            return Redirect("OrderAdminPage");
        }
    }
}
