namespace CollectionsManagment.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
    }
}
