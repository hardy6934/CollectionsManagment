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
        private readonly ITagService tagService;

        public TagItemService(IMapper mapper, IUnitOfWork unitOfWork, ITagService tagService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.tagService = tagService;
        }
        public async Task<int> CreateTagItemAsync(TagItemDTO dto)
        {
            try
            {
                await unitOfWork.TagItems.AddAsync(mapper.Map<TagItem>(dto));
                return await unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TagItemDTO>> GetAllTagsByItemId(int itemId)
        {
            try
            {
                //var tagItems = await unitOfWork.TagItems.FindBy(x => x.ItemId.Equals(itemId)).Include(x => x.Tag).ToListAsync();
                //var tags = tagItems.Select(x => mapper.Map<Tag>(x));

                //return tags.Select(x => mapper.Map<TagDTO>(x)).ToList();

                var tagItems = await unitOfWork.TagItems.FindBy(x => x.ItemId.Equals(itemId)).Include(x => x.Tag).ToListAsync();
                return tagItems.Select(x => mapper.Map<TagItemDTO>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> RemoveTagItem(TagItemDTO dto)
        {
            try
            {
                unitOfWork.TagItems.Remove(mapper.Map<TagItem>(dto));
                return await unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TagItemDTO> GetTagItemByIdAsync(int id)
        {
            try
            {
                var tagItem = await unitOfWork.TagItems.FindBy(x => x.Id.Equals(id)).Include(x => x.Tag).AsNoTracking().FirstOrDefaultAsync();
                return mapper.Map<TagItemDTO>(tagItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TagItemDTOForTagCloud>> TagCloudAsync()
        {
            try
            {
                var tagCloud = await unitOfWork.TagItems.Get().Include(x => x.Tag).GroupBy(x => x.TagId)
                  .Select(y => new TagItemDTOForTagCloud { TagName = y.FirstOrDefault().Tag.TagName, Count = y.Count() })
                  .ToListAsync();

                return tagCloud;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TagItemDTO>> GetItemsByTagNameAsync(string tagName)
        {
            try
            {
                var tagid = await tagService.GetTagIdByTagNameAsync(tagName);
                var tagitems = await unitOfWork.TagItems.Get().Where(x => x.TagId.Equals(tagid)).Include(x => x.Item).ToListAsync();


                return tagitems.Select(x => mapper.Map<TagItemDTO>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
         

    }
}
