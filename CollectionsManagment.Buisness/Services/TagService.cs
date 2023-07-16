using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
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
            await unitOfWork.Tags.AddAsync(mapper.Map<Tag>(dto));
            return await unitOfWork.Commit();
        }
          
        public async Task<List<TagDTO>> GetAllTagsAsync()
        {
            var tags = await unitOfWork.Tags.GetAllAsync();
            return tags.Select(x=>mapper.Map<TagDTO>(x)).ToList();
        }

        public async Task<int> RemoveTagAsync(TagDTO dto)
        {
            unitOfWork.Tags.Remove(mapper.Map<Tag>(dto));
            return await unitOfWork.Commit();
        }

        public async Task<int> UpdateTagAsync(TagDTO dto)
        {
            unitOfWork.Tags.Update(mapper.Map<Tag>(dto));
            return await unitOfWork.Commit();
        }
    }
}
