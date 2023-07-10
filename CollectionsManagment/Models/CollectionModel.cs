using CollectionsManagment.DataBase.Entities;

namespace CollectionsManagment.Models
{
    public class CollectionModel
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }
        public string? Description { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<ItemModel> Items { get; set; } 
    }
}
