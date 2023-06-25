using CollectionsManagment.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.Abstractrions
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int id);

        Task<int> CreateUserAsync(UserDTO dto);
        UserDTO CreateDefaultUser(int IdAccount, int IdRole );
        Task<UserDTO> GetUsersByAccountId(int AccountId);
        Task<List<UserDTO>> GetAllUsers();
        Task<int> UpdateUserAsync(UserDTO dto);
        Task<int> ChangeUserRoleByEmail(string email, string newRole);
        Task<UserDTO> GetUserByIdWithIncludsAsync(int id);
    }
}
