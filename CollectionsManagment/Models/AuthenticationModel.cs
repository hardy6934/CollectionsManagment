using System.ComponentModel.DataAnnotations;

namespace CollectionsManagment.Models
{
    public class AuthenticationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
    }
}
