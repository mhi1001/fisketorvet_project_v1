using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.AdminSection
{
    public class AdminPageModel : PageModel
    {
        public void OnGet()
        {

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
