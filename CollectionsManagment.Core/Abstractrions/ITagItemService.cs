using CollectionsManagment.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.Abstractrions
{
    public interface ITagItemService
    {
        Task<int> CreateTagItemAsync(TagItemDTO dto);
        Task<List<TagItemDTO>> GetAllTagsByItemId(int itemId);
        Task<int> RemoveTagItem(TagItemDTO dto);
        Task<TagItemDTO> GetTagItemByIdAsync(int id);



    }
}
