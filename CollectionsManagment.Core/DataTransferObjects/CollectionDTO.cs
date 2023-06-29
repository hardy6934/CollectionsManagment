using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.DataTransferObjects
{
    public class CollectionDTO
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }
        public string? Description { get; set; }

        public int UserId { get; set; } 
        public string UserName { get; set; }
        public List<ItemDTO> ItemsDTO { get; set; }  
    }
}
