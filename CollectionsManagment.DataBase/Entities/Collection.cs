using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.DataBase.Entities
{
    public class Collection : IBaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Item> Items { get; set;}
    }
}
