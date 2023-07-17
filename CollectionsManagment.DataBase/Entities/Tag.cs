

namespace CollectionsManagment.DataBase.Entities
{
    public class Tag : IBaseEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public List<Item> Items { get; set; }
        public List<TagItem> TagItem { get; set; }
    }
}
