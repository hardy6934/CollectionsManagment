using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.DataTransferObjects
{
    public class TagItemDTO
    {
        public int Id { get; set; }
        public ItemDTO Item { get; set; }
        public int ItemId { get; set; }
        public TagDTO Tag { get; set; }
        public int TagId { get; set; }
    }
}
