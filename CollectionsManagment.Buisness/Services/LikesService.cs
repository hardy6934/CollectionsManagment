using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;
using CollectionsManagment.DataBase.Migrations;
using System.Security.Cryptography.X509Certificates;

namespace CollectionsManagment.Buisness.Services
{
    public class LikesService : ILikesService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public LikesService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> CreateLikeAsync(int itemId, int userId)
        { 
             
            Like like = new()
            {
                ItemId = itemId,
                UserId = userId
            };

            if (!unitOfWork.Likes.Get().Any(x => x.UserId.Equals(like.UserId) && x.ItemId.Equals(like.ItemId)))
            {
                await unitOfWork.Likes.AddAsync(like);
                return await unitOfWork.Commit();
            }
            else return 0;
        }
    }
}
