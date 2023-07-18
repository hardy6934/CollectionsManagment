using CollectionsManagment.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.Abstractrions
{
    public interface IRoleService
    {
        Task<int> FindRoleIdByRoleName(string RoleName); 
        Task<List<RoleDTO>> GetAllRolesAsync();
        Task<string> GetRoleByAccountName(string accName);
    }


}
