using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;

namespace CollectionsManagment.MappingProfiles
{
    public class TagItemProfile : Profile
    {
        public TagItemProfile()
        {
            CreateMap<TagItem, TagItemDTO>();
            CreateMap<TagItemDTO, TagItem>();


            CreateMap<TagItemDTO, TagItemModel>();
            CreateMap<TagItemModel, TagItemDTO>();


            CreateMap<TagItem, Tag>().ForMember(ent=>ent.Id, opt=>opt.MapFrom(ti=>ti.Tag.Id)).ForMember(ent => ent.TagName, opt => opt.MapFrom(ti => ti.Tag.TagName)); 
        }
    }
}
