using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;

namespace CollectionsManagment.MappingProfiles
{
    public class LikesProfile : Profile
    {
        public LikesProfile()
        {
            CreateMap<Like, LikeDTO>();
            CreateMap<LikeDTO, Like>();


            CreateMap<LikeDTO, LikeModel>();
            CreateMap<LikeModel, LikeDTO>();
        }
    }
}
