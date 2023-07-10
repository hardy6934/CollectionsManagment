using CollectionsManagment.Core.DataTransferObjects;

namespace CollectionsManagment.Models
{
    public class ItemModel
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

        public string? FirstBoolFieldName { get ; set; } 

        public string StringForFirstBoolField
        {
            get {
                return "";
            }
            set {
                if (value != null)
                FirstBoolField = Convert.ToBoolean(value);
                else FirstBoolField= null;
            }
        }
        public bool? FirstBoolField { get; set; }
        public string? SecondBoolFieldName { get; set; }

        public string StringForSecondBoolField
        {
            get
            {
                return "";
            }
            set
            {
                if (value != null)
                    SecondBoolField = Convert.ToBoolean(value);
                else SecondBoolField = null;
            }
        }
        public bool? SecondBoolField { get; set; }
        public string? ThirdtBoolFieldName { get; set; }

        public string StringForThirdBoolField
        {
            get
            {
                return "";
            }
            set
            {
                if (value != null)
                    ThirdtBoolField = Convert.ToBoolean(value);
                else ThirdtBoolField = null;
            }
        }
        public bool? ThirdtBoolField { get; set; }

        public List<LikeDTO> Likes { get; set; }
        public List<CommentDTO> Comments { get; set; }

        public List<TagDTO> Tags { get; set; }

        public int CollectionId { get; set; }
        public CollectionDTO Collection { get; set; }
    }
}
