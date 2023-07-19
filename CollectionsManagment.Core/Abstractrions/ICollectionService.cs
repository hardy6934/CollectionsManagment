using CollectionsManagment.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.Abstractrions
{
    public interface ICollectionService
    {
        Task<CollectionDTO> GetCollectionByIdAsync(int id); 
        Task<int> CreateCollectionAsync(CollectionDTO dto);  
        Task<List<CollectionDTO>> GetAllCollectionsAsync();
        Task<int> UpdateCollectionAsync(CollectionDTO dto);
        Task<int> DeleteCollectionAsync(CollectionDTO dto);
        Task<CollectionDTO> GetCollectionByIdWithIncludsAsync(int id);
        Task<List<CollectionDTO>> GetAllCollectionsForUserAsync(int id);
        Task<List<CollectionDTO>> GetTopFiveBigestCollectionsAsync();
        //Task<List<ItemDTO>> GetThreeLastCreatedItemsAsync(int userId);
    }
}
