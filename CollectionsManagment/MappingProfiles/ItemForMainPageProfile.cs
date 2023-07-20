using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;

namespace CollectionsManagment.MappingProfiles
{
    public class ItemForMainPageProfile : Profile
    {
        public ItemForMainPageProfile()
        {

            CreateMap<Item, ItemsDTOForMainPage>().ForMember(dto => dto.CollectionName, opt => opt.MapFrom(acc => acc.Collection.CollectionName)); 


            CreateMap<ItemsDTOForMainPage, ItemsModelForMainPage>();
            CreateMap<ItemsModelForMainPage, ItemsDTOForMainPage>();

        }
    }
}
