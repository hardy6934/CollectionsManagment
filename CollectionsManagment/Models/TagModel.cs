using CollectionsManagment.DataBase.Entities;

namespace CollectionsManagment.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public List<ItemModel> Items { get; set; }
    }
}
