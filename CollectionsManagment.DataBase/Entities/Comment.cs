using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.DataBase.Entities
{
    public class Comment : IBaseEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime dateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
