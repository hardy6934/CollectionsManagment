namespace CollectionsManagment.Models
{
    public class LikeModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SenderName { get; set; }

        public int ItemId { get; set; }
    }
}
