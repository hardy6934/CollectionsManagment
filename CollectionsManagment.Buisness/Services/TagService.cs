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
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TagService(IUnitOfWork unitOfWork, IMapper mapper)
        {

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }
        public async Task<int> CreateTagAsync(TagDTO dto)
        {
            try
            {
                await unitOfWork.Tags.AddAsync(mapper.Map<Tag>(dto));
                return await unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }
          
        public async Task<List<TagDTO>> GetAllTagsAsync()
        {
            try
            {
                var tags = await unitOfWork.Tags.GetAllAsync();
                return tags.Select(x => mapper.Map<TagDTO>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> RemoveTagAsync(TagDTO dto)
        {
            try
            {
                unitOfWork.Tags.Remove(mapper.Map<Tag>(dto));
                return await unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateTagAsync(TagDTO dto)
        {
            try
            {
                unitOfWork.Tags.Update(mapper.Map<Tag>(dto));
                return await unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TagDTO> GetTagByIdAsync(int id)
        {
            try
            {
                var tag = await unitOfWork.Tags.GetByIdAsync(id);
                return mapper.Map<TagDTO>(tag);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> GetTagIdByTagNameAsync(string name)
        {
            try
            {
                var id = (await unitOfWork.Tags.Get().Where(x => x.TagName.Equals(name)).FirstOrDefaultAsync()).Id;

                return id;
            }
            catch (Exception)
            {
                throw;
            }
             
        }
    }
}
