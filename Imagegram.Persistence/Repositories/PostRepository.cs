using Imagegram.Application.Contracts.Persistence;
using Imagegram.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagegram.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly ImagegramDbContext _dbContext;

        public PostRepository(ImagegramDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Post>> GetPostsOrderByCommentCount(string next)
        {
            // TODO: Implement cursor pagination by switching to graph databases since EF Core
            // doesn't have a good implementation of cursor pagination yet (Based on my research).
            // Also, it is highly recommended to use graph databases for these kinds of entities with hierarchal 
            // relationships. I just don't have much experience with the tech which is why I did not implement it.
            var posts = _dbContext.Posts.Include(p => p.User)
                                        .Include(p => p.Comments)
                                        .ThenInclude(c => c.User)
                                        .OrderByDescending(p => p.Comments.Count());

            return await posts.ToListAsync();
        }
    }
}
