using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Buisness.Services
{
    public class TagItemService : ITagItemService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public TagItemService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> CreateTagItemAsync(TagItemDTO dto)
        {
            await unitOfWork.TagItems.AddAsync(mapper.Map<TagItem>(dto));
            return await unitOfWork.Commit();
        }

        public async Task<List<TagItemDTO>> GetAllTagsByItemId(int itemId)
        {
            //var tagItems = await unitOfWork.TagItems.FindBy(x => x.ItemId.Equals(itemId)).Include(x => x.Tag).ToListAsync();
            //var tags = tagItems.Select(x => mapper.Map<Tag>(x));

            //return tags.Select(x => mapper.Map<TagDTO>(x)).ToList();

            var tagItems = await unitOfWork.TagItems.FindBy(x => x.ItemId.Equals(itemId)).Include(x => x.Tag).ToListAsync();
            return tagItems.Select(x => mapper.Map<TagItemDTO>(x)).ToList();
        }

        public async Task<int> RemoveTagItem(TagItemDTO dto)
        {
            unitOfWork.TagItems.Remove(mapper.Map<TagItem>(dto));
            return await unitOfWork.Commit();
        }

        public async Task<TagItemDTO> GetTagItemByIdAsync(int id)
        {
            var tagItem = await unitOfWork.TagItems.FindBy(x => x.Id.Equals(id)).Include(x => x.Tag).AsNoTracking().FirstOrDefaultAsync();
            return mapper.Map<TagItemDTO>(tagItem);
        }

    }
}
