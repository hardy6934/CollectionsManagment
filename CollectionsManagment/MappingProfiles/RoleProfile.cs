using AutoMapper;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.Models;

namespace CollectionsManagment.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();

        }


    }
}
