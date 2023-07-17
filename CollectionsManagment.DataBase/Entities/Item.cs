using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.DataBase.Entities
{
    public class Item : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public string? FirstNumericFieldName { get; set; }
        public int? FirstNumericField { get; set; }
        public string? SecondNumericFieldName { get; set; }
        public int? SecondNumericField { get; set; }
        public string? ThirdNumericFieldName { get; set; }
        public int? ThirdNumericField { get; set; }

        public string? FirstStringFieldName { get; set; }
        public string? FirstStringField { get; set; }
        public string? SecondStringFieldName { get; set; }
        public string? SecondStringField { get; set; }
        public string? ThirdStringFieldName { get; set; }
        public string? ThirdStringField { get; set; }

        public string? FirstBigStringFieldName { get; set; }
        public string? FirstBigStringField { get; set; }
        public string? SecondBigStringFieldName { get; set; }
        public string? SecondBigStringField { get; set; }
        public string? ThirdBigStringFieldName { get; set; }
        public string? ThirdBigStringField { get; set; }

        public string? FirstDatetimeFieldName { get; set; }
        public DateTime? FirstDatetimeField { get; set; }
        public string? SecondDatetimeFieldName { get; set; }
        public DateTime? SecondDatetimeField { get; set; }
        public string? ThirdDatetimeFieldName { get; set; }
        public DateTime? ThirdDatetimeField { get; set; }

        public string? FirstBoolFieldName { get; set; }
        public bool? FirstBoolField { get; set; }
        public string? SecondBoolFieldName { get; set; }
        public bool? SecondBoolField { get; set; }
        public string? ThirdtBoolFieldName { get; set; }
        public bool? ThirdtBoolField { get; set; }

        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }

        public List<Tag> Tags { get; set; }
        public List<TagItem> TagItem { get; set; }

        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}
