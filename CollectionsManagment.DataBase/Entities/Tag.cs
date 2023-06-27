

namespace CollectionsManagment.DataBase.Entities
{
    public class Tag : IBaseEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public Collection Collection { get; set; }
    }
}
