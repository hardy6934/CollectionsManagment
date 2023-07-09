using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollectionsManagment.Buisness.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CollectionService(IMapper mapper, IUnitOfWork unitOfWork){
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> CreateCollectionAsync(CollectionDTO dto)
        {
            await unitOfWork.Collections.AddAsync(mapper.Map<Collection>(dto)); 
            return await unitOfWork.Commit();
        }

        public async Task<int> DeleteCollectionAsync(CollectionDTO dto)
        {
            unitOfWork.Collections.Remove(mapper.Map<Collection>(dto));
            return await unitOfWork.Commit();
        }

        public async Task<List<CollectionDTO>> GetAllCollectionsAsync()
        {
            var dtos = await unitOfWork.Collections.GetAllAsync();
            return dtos.Select(x=>mapper.Map<CollectionDTO>(x)).ToList();
        }

        public async Task<CollectionDTO> GetCollectionByIdAsync(int id)
        {
            var dto = await unitOfWork.Collections.GetByIdAsync(id);
            return mapper.Map<CollectionDTO>(dto);
        }

        public Task<CollectionDTO> GetCollectionByIdWithIncludsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCollectionAsync(CollectionDTO dto)
        {
            unitOfWork.Collections.Update(mapper.Map<Collection>(dto));
            return await unitOfWork.Commit();
        } 
        
        public async Task<List<CollectionDTO>> GetAllCollectionsForUserAsync(int id)
        {
            var dtos = await unitOfWork.Collections.Get().Select(x=>x).Where(x=>x.UserId.Equals(id)).ToListAsync();
            return dtos.Select(x=>mapper.Map<CollectionDTO>(x)).ToList();
        }


         
    }
}
