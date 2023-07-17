using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.DataBase.Entities
{
    public class TagItem : IBaseEntity
    {
        public int Id { get; set; }
        public Item Item{ get; set; }
        public int ItemId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
