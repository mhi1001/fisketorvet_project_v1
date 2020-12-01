using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.UserSection
{
    public class UserPageModel : PageModel
    {
        [BindProperty]
        public Customer cust { set; get; }
        public CustomerCatalog catalog { set; get; }
        public IActionResult OnGet(int id)
        {
            catalog.GetCustomer(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            return Page();
        }
    }
}
