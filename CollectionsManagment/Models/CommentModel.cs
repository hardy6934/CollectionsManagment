namespace CollectionsManagment.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime dateTime { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int ItemId { get; set; }
    }
}
