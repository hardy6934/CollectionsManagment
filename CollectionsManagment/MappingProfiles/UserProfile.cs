using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;

namespace CollectionsManagment.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserDTO>().ForMember(dto => dto.AccountEmail, opt => opt.MapFrom(acc => acc.Account.Email))
          .ForMember(dto => dto.RoleName, opt => opt.MapFrom(acc => acc.Role.RoleName));
            CreateMap<UserDTO, User>();


            CreateMap<UserDTO, UserModel>();
            CreateMap<UserModel, UserDTO>();

            CreateMap<UserDTO, UserShortDataModel>();
        }
    }
}
