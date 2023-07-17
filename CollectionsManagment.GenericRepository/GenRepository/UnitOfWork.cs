using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.DataBase;
using CollectionsManagment.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.GenericRepository.GenRepository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CollectionsManagmentContext context;
        public IRepository<Account> Accounts { get; }
        public IRepository<Collection> Collections { get; }
        public IRepository<Comment> Comments { get; }
        public IRepository<Item> Items { get; }
        public IRepository<Like> Likes { get; }
        public IRepository<Role> Role { get; }
        public IRepository<User> Users { get; } 
        public IRepository<Tag> Tags { get; } 
        public IRepository<TagItem> TagItems { get; } 


        public UnitOfWork(CollectionsManagmentContext context,
            IRepository<User> users,
            IRepository<Account> accounts,
            IRepository<Collection> collections,
            IRepository<Comment> comments,
            IRepository<Item> items,
            IRepository<Like> likes,
            IRepository<Role> role, 
            IRepository<TagItem> tagItems, 
            IRepository<Tag> tags )
        {
            this.context = context;
            Users = users;
            Accounts = accounts;
            Collections = collections;
            Likes = likes;
            Comments= comments;
            Items = items; 
            Role= role; 
            Tags= tags; 
            TagItems= tagItems; 
        } 


        public async Task<int> Commit()
        {
            return await context.SaveChangesAsync();
        }
    }
}
    