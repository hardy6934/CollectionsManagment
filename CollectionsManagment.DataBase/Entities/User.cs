using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.DataBase.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string? Location { get; set; }
        public string? FilePath { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
         

        public List<Collection> Collections { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
