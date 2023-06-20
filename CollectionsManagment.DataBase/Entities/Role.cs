using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.DataBase.Entities
{
    public class Role : IBaseEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
