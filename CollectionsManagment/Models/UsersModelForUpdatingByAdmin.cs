using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollectionsManagment.Models
{
    public class UsersModelForUpdatingByAdmin
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string? Location { get; set; }
        public IFormFile? Photo { get; set; }
        public string? FilePath { get; set; }

        public int AccountId { get; set; }
        public string AccountEmail { get; set; }

        public int RoleId { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
