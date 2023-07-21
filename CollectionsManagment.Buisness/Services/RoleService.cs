using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Buisness.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        public async Task<int> FindRoleIdByRoleName(string RoleName)
        {
            try
            {
                var id = (await unitOfWork.Role.Get().AsNoTracking().FirstOrDefaultAsync(x => x.RoleName == RoleName)).Id;
                return id;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<RoleDTO>> GetAllRolesAsync()
        {
            try
            {
                var roles = await unitOfWork.Role.GetAllAsync();

                return roles.Select(x => mapper.Map<RoleDTO>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetRoleByAccountName(string accName)
        {
            try
            {
                var acc = await unitOfWork.Accounts.Get().Where(x => x.Email.Equals(accName)).FirstOrDefaultAsync();
                var user = await unitOfWork.Users.Get().Where(x => x.AccountId.Equals(acc.Id)).Include(x => x.Role).FirstOrDefaultAsync();
                return user.Role.RoleName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
