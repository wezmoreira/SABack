using Microsoft.EntityFrameworkCore;
using solidariedadeAnonima.Domain.Entities;
using solidariedadeAnonima.Domain.Repositories;
using solidariedadeAnonima.Infra.Context;

namespace solidariedadeAnonima.Infra.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public CommentRepository(DataContext context)
        {
            _dataContext = context;
        }

        private readonly DataContext _dataContext;

        public async Task AddCommentAsync(Comments comment)
        {
            await _dataContext.Comments.AddAsync(comment);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Comments>> GetCommentsAsync()
        {
            return await _dataContext.Comments.AsNoTracking().ToListAsync();
        }
    }
}
