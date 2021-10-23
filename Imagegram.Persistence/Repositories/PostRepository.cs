using Imagegram.Application.Persistence.Contracts;
using Imagegram.Domain;
using Microsoft.EntityFrameworkCore;
using System;
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
            var posts = _dbContext.Posts.OrderBy(_ => _.Comments.Count());

            return await posts.ToListAsync();
        }
    }
}
