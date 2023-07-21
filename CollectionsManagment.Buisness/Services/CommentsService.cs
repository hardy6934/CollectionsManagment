using AutoMapper;
using CollectionsManagment.Abstractions.GenRepositoryAbstractions;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Core.DataTransferObjects;
using CollectionsManagment.DataBase.Entities;

namespace CollectionsManagment.Buisness.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CommentsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> CreateCommentAsync(CommentDTO dto)
        {
            try
            {
                await unitOfWork.Comments.AddAsync(mapper.Map<Comment>(dto));
                return await unitOfWork.Commit();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
