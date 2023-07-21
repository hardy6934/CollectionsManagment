using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

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
            try
            {

                await unitOfWork.Collections.AddAsync(mapper.Map<Collection>(dto));
                return await unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

           
        }

        public async Task<int> DeleteCollectionAsync(CollectionDTO dto)
        {
            try
            {
                unitOfWork.Collections.Remove(mapper.Map<Collection>(dto));
                return await unitOfWork.Commit();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<CollectionDTO>> GetAllCollectionsAsync()
        {
            try
            {

                var dtos = await unitOfWork.Collections.GetAllAsync();
                return dtos.Select(x => mapper.Map<CollectionDTO>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<CollectionDTO> GetCollectionByIdAsync(int id)
        {
            try
            {
                var dto = await unitOfWork.Collections.GetByIdAsync(id);
                return mapper.Map<CollectionDTO>(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<CollectionDTO> GetCollectionByIdWithIncludsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCollectionAsync(CollectionDTO dto)
        {
            try
            {
                unitOfWork.Collections.Update(mapper.Map<Collection>(dto));
                return await unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

        } 
        
        public async Task<List<CollectionDTO>> GetAllCollectionsForUserAsync(int id)
        {
            try
            {
                var dtos = await unitOfWork.Collections.Get().Select(x => x).Where(x => x.UserId.Equals(id)).ToListAsync();
                return dtos.Select(x => mapper.Map<CollectionDTO>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<CollectionDTO>> GetTopFiveBigestCollectionsAsync()
        {
            try
            {
                var dtos = await unitOfWork.Collections.Get().Include(x => x.Items).ToListAsync();

                dtos.Sort((x, y) => y.Items.Count().CompareTo(x.Items.Count()));

                var topFive = dtos.Take(5).ToList();

                return topFive.Select(x => mapper.Map<CollectionDTO>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }

              
        }


        public async Task<List<CollectionDTO>> FindCollectionsByNameOrDescAsync(string name)
        {
            try
            {
                var dtos = await unitOfWork.Collections.FindBy(x => x.CollectionName.Contains(name) || x.Description.Contains(name)).Include(x => x.Items).ToListAsync();

                return dtos.Select(x => mapper.Map<CollectionDTO>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }


        }


    }
}
