using solidariedadeAnonima.Domain.Entities;

namespace solidariedadeAnonima.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comments comment);
        Task<List<Comments>> GetCommentsAsync();
    }
}
