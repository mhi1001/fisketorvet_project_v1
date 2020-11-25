using System.ComponentModel.DataAnnotations;

namespace fisketorvet_project_v1.Models
{
    public class SiteUser
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}