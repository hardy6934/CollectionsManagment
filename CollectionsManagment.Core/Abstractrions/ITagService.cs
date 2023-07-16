using CollectionsManagment.Core.DataTransferObjects;

namespace CollectionsManagment.Core.Abstractrions
{
    public interface ITagService 
    {
        Task<List<TagDTO>> GetAllTagsAsync(); 
        Task<int> CreateTagAsync(TagDTO dto); 
        Task<int> RemoveTagAsync(TagDTO dto); 
        Task<int> UpdateTagAsync(TagDTO dto); 
    }
}
