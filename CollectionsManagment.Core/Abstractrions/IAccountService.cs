using CollectionsManagment.Core.DataTransferObjects; 

namespace CollectionsManagment.Core.Abstractrions
{
    public interface IAccountService
    {
        Task<int> CreateAccountAsync(AccountDTO dto);

        bool IsEmailExist(string email);

        Task EditAccountAsync(AccountDTO dto);

        Task RemoveAccountAsync(AccountDTO dto);

        Task<bool> IsAccountExistAsync(AccountDTO dto);

        Task<bool> CheckUserPassword(AccountDTO dto);

        Task<AccountDTO> GetAccountByIdAsync(int id);

        Task<int> GetIdAccountByEmailAsync(string email);
        Task<int> UpdateUserPasswordAsync(AccountDTO dto);
    }
}
