using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.DataTransferObjects
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; } 
    }
}
