using CollectionsManagment.DataBase.Entities;

namespace CollectionsManagment.Models
{
    public class TagItemModel
    {
        public int Id { get; set; }
        public ItemModel Item { get; set; }
        public int ItemId { get; set; }
        public TagModel Tag { get; set; }
        public int TagId { get; set; }
    }
}
