using System.ComponentModel.DataAnnotations;
using fisketorvet_project_v1.Validation;

namespace fisketorvet_project_v1.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [SameUsername(ErrorMessage = "Username already exists, please insert another one")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage="Please enter the email")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage="Please enter the password")]
        public string Password { get; set; }
        public bool Admin { set; get; }
        
    }
}
