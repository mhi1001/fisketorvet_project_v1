using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace fisketorvet_project_v1.Pages.UserSection
{
    public class UserPageModel : PageModel
    {
        [BindProperty]
        public Customer cust { set; get; }

        public CustomerCatalog catalog;

        public UserPageModel(CustomerCatalog c)
        {
            catalog = c;
        }
        public IActionResult OnGet(int id)
        {
            cust=JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("cat"));
            //cust=catalog.GetCustomer(id);
            return Page();
        }

        public IActionResult OnPost(Customer c)
        {
            //cust = catalog.GetCustomer(id);
            return Page();
        }
    }
}
