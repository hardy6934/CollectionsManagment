using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;

namespace CollectionsManagment.MappingProfiles
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile() {

            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();


            CreateMap<AccountDTO, AuthenticationModel>().ForMember(model=>model.Password, dto=>dto.MapFrom(change=>change.PasswordHash));
            CreateMap<AuthenticationModel, AccountDTO>().ForMember(dto => dto.PasswordHash, model => model.MapFrom(change => change.Password));

        }
    }
}
