using CollectionsManagment.DataBase.Entities;
using Microsoft.EntityFrameworkCore; 

namespace CollectionsManagment.DataBase
{
    public class CollectionsManagmentContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; } 
        public DbSet<Collection> Collections { get; set; } 
        public DbSet<Comment> Comments { get; set; } 
        public DbSet<Item> Items { get; set; } 
        public DbSet<Like> Likes { get; set; } 
        public DbSet<Role> Roles { get; set; } 
        public DbSet<User> Users { get; set; }  
        public DbSet<Tag> Tags { get; set; }  

        public CollectionsManagmentContext(DbContextOptions<CollectionsManagmentContext> options)
            : base(options)
        {

        }
    }
}
