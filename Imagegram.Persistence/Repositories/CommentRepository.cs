using Imagegram.Application.Contracts.Persistence;
using Imagegram.Domain;

namespace Imagegram.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ImagegramDbContext dbContext) : base(dbContext)
        {
        }
    }
}
