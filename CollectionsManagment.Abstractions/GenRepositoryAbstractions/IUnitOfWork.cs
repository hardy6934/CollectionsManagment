using CollectionsManagment.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Abstractions.GenRepositoryAbstractions
{
    public interface IUnitOfWork
    {
        IRepository<Account> Accounts { get; }
        IRepository<Collection> Collections { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Item> Items { get; }
        IRepository<Like> Likes { get; }
        IRepository<Role> Role { get; }
        IRepository<User> Users { get; }
         
        Task<int> Commit();
    }
}
