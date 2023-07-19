using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;

namespace CollectionsManagment.MappingProfiles
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile() { 

            CreateMap<Collection, CollectionDTO>().ForMember(dto => dto.UserName, opt => opt.MapFrom(acc => acc.User.FullName));
            CreateMap<CollectionDTO, Collection>();


            CreateMap<CollectionDTO, CollectionModel>();
            CreateMap<CollectionModel, CollectionDTO>();

        }
    }
}
