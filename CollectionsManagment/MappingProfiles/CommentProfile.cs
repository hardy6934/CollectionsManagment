using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;

namespace CollectionsManagment.MappingProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>().ForMember(dto=>dto.SenderName, opt=>opt.MapFrom(ent=>ent.User.FullName));
            CreateMap<CommentDTO, Comment>();


            CreateMap<CommentDTO, CommentModel>();
            CreateMap<CommentModel, CommentDTO>();
        }
    }
}
