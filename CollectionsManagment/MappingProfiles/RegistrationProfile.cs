using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;

namespace CollectionsManagment.MappingProfiles
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile() {

            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();


            CreateMap<AccountDTO, RegistrationModel>().ForMember(model=>model.Password, dto=>dto.MapFrom(change=>change.PasswordHash));
            CreateMap<RegistrationModel, AccountDTO>().ForMember(dto=>dto.PasswordHash, model=>model.MapFrom(change=>change.Password));
        }
    }
}
