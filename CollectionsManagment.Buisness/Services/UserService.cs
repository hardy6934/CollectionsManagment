using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using Microsoft.EntityFrameworkCore; 

namespace CollectionsManagment.Buisness.Services
{
    public class UserService : IUserService
    { 
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;        
       

        public UserService(IUnitOfWork unitOfWork, IMapper mapper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper; 

        }

        public UserDTO CreateDefaultUser(int IdAccount, int IdRole )
        {
            try
            {
                var user = new UserDTO { FullName = "User", Location = "", Birthday = new DateTime(), AccountId = IdAccount, RoleId = IdRole };
                return user;
            }
            catch (Exception)
            { 
                throw;
            } 
        }

        public async Task<int> CreateUserAsync(UserDTO dto)
        {
            try
            {
                await unitOfWork.Users.AddAsync(mapper.Map<User>(dto));
                return await unitOfWork.Commit();
            }
            catch (Exception)
            { 
                throw;
            } 
        }

        public async Task<UserDTO> GetUsersByAccountId(int Accountid)
        {
            try
            {
                var user = await unitOfWork.Users.FindBy(us => us.AccountId.Equals(Accountid), user => user.Account, us => us.Role ).FirstOrDefaultAsync(); 
                return mapper.Map<UserDTO>(user);
            }
            catch (Exception)
            { 
                throw;
            } 
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = await unitOfWork.Users.Get().Include(x=>x.Account).Include(x=>x.Role).ToListAsync(); 
                return users.Select(x => mapper.Map<UserDTO>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> ChangeUserRoleByEmail(string email, string newRole)
        {
            try
            {
                var accountId = unitOfWork.Accounts.FindBy(ac => ac.Email.Equals(email)).FirstOrDefault().Id;
                var user = await unitOfWork.Users.FindBy(us => us.AccountId.Equals(accountId)).FirstOrDefaultAsync();

                var role = await unitOfWork.Role.FindBy(x=>x.RoleName.Equals(newRole)).AsNoTracking().FirstOrDefaultAsync();
                if (role != null && user != null)
                {
                    user.RoleId = role.Id;
                    unitOfWork.Users.Update(user);
                    return await unitOfWork.Commit();
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            try
            {
                return mapper.Map<UserDTO>(await unitOfWork.Users.GetByIdAsync(id));
            }
            catch (Exception)
            { 
                throw;
            } 
        }
        
        public async Task<UserDTO> GetUserByIdWithIncludsAsync(int id)
        {
            try
            {
                var user = await unitOfWork.Users.FindBy(us => us.Id.Equals(id), user => user.Account, us => us.Role).FirstOrDefaultAsync();
                return mapper.Map<UserDTO>(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateUserAsync(UserDTO dto)
        {
            try
            {
                unitOfWork.Users.Update(mapper.Map<User>(dto)); 
                return await unitOfWork.Commit();
            }
            catch (Exception)
            { 
                throw;
            }
            
        }
         

    }
}
