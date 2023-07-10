using CollectionsManagment.DataBase.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionsManagment.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime dateTime { get; set; } 
        public int UserId { get; set; }
        public string SenderName { get; set; }
        public int ItemId { get; set; }
    }
}
