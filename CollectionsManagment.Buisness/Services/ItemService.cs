using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollectionsManagment.Buisness.Services
{
    public class ItemService : IItemService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ItemService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> CreateItemAsync(ItemDTO dto)
        {
            await unitOfWork.Items.AddAsync(mapper.Map<Item>(dto));
            return await unitOfWork.Commit();
        }

        public async Task<int> DeleteItemAsync(ItemDTO dto)
        {
            unitOfWork.Items.Remove(mapper.Map<Item>(dto));
            return await unitOfWork.Commit();
        }

        public async Task<ItemDTO> GetItemById(int id)
        {
            var item = await unitOfWork.Items.FindBy(item => item.Id.Equals(id), item => item.Comments, item => item.Likes).FirstOrDefaultAsync();
            return mapper.Map<ItemDTO>(item);
        } 
        
        public async Task<ItemDTO> GetItemByIdWithCommentsAndUsers(int id)
        {
            var item = await unitOfWork.Items.Get().Where(x=>x.Id.Equals(id)).Include(x=>x.Likes).Include(x=>x.Comments).ThenInclude(x=>x.User).FirstOrDefaultAsync();
            return mapper.Map<ItemDTO>(item);
        }
         

        public async Task<List<ItemDTO>> GetItemsByCollectionIdAsync(int id)
        {
            var items = await unitOfWork.Items.FindBy(item => item.CollectionId.Equals(id), item => item.Comments, item => item.Likes).ToListAsync();
            return items.Select(x=> mapper.Map<ItemDTO>(x)).ToList();
        }

        public async Task<int> UpdateItemAsync(ItemDTO dto)
        {
            unitOfWork.Items.Update(mapper.Map<Item>(dto));
            return await unitOfWork.Commit();
        }

        public async Task<bool> IsCollectionEmpty(int collectionId)
        {
            var collection = await unitOfWork.Collections.FindBy(col => col.Id.Equals(collectionId), col => col.Items).FirstOrDefaultAsync();
            return collection.Items.Any(); 
        }
        public async Task<ItemDTO> GetFirstItemFromCollectionByCollectionId(int collectionId)
        {
            var collection = await unitOfWork.Collections.FindBy(col => col.Id.Equals(collectionId), col => col.Items).FirstOrDefaultAsync();
            return mapper.Map<ItemDTO>(collection.Items.FirstOrDefault()); 
        } 
        
        public async Task<string> GetAccountIdByItemIdAsync(int id)
        {
            var Item = await unitOfWork.Items.Get().Where(x => x.Id.Equals(id)).Include(x => x.Likes).Include(x => x.Comments).Include(x=>x.Collection).ThenInclude(x => x.User).FirstOrDefaultAsync();
            return Item.Collection.User.FullName; 
        }
    }
}
