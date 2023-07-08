using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;
using Humanizer;

namespace CollectionsManagment.MappingProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile() {
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();


            CreateMap<ItemDTO, ItemModel>();
            CreateMap<ItemModel, ItemDTO>();
        }

    }
}
