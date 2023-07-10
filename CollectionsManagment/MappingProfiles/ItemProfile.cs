using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;
using Humanizer;

namespace CollectionsManagment.MappingProfiles
{
    public class ItemProfile : Profile
    { 
        public ItemProfile( ) {

            CreateMap<Comment, CommentDTO>().ForMember(dto => dto.SenderName, opt => opt.MapFrom(ent => ent.User.FullName)); ;
            CreateMap<CommentDTO, Comment>();


            CreateMap<CommentDTO, CommentModel>();
            CreateMap<CommentModel, CommentDTO>();



            CreateMap<Like, LikeDTO>();
            CreateMap<LikeDTO, Like>();


            CreateMap<LikeDTO, LikeModel>();
            CreateMap<LikeModel, LikeDTO>();




            CreateMap<Item, ItemDTO>().ForMember(dst => dst.CommentsDTO, src => src.MapFrom(c => c.Comments)).ForMember(dst => dst.LikesDTO, src => src.MapFrom(c => c.Likes)); 
            CreateMap<ItemDTO, Item>();


            CreateMap<ItemDTO, ItemModel>().ForMember(dst => dst.Comments, src => src.MapFrom(c => c.CommentsDTO)).ForMember(dst => dst.Likes, src => src.MapFrom(c => c.LikesDTO));
            CreateMap<ItemModel, ItemDTO>();
        }

    }
}
