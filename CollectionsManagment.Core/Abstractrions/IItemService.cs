using CollectionsManagment.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.Abstractrions
{
    public interface IItemService
    {
        Task<List<ItemDTO>> GetItemsByCollectionIdAsync(int id);
        Task<int> CreateItemAsync(ItemDTO dto); 
        Task<int> UpdateItemAsync(ItemDTO dto);
        Task<int> DeleteItemAsync(ItemDTO dto); 
        Task<ItemDTO> GetItemById(int id);
        Task<bool> IsCollectionEmpty(int collectionId);
        Task<ItemDTO> GetFirstItemFromCollectionByCollectionId(int collectionId);
        Task<ItemDTO> GetItemByIdWithCommentsAndUsers(int id);
        Task<string> GetAccountIdByItemIdAsync(int id);
        Task<List<ItemsDTOForMainPage>> GetThreeLastCreatedItemsAsync();
    }
}
