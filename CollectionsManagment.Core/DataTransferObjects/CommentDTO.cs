using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.DataTransferObjects
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime dateTime { get; set; }
        public int SenderId { get; set; }

        public int ItemId { get; set; } 
    }
}
