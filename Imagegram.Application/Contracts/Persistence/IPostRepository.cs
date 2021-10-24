using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Contracts.Persistence
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IReadOnlyList<Post>> GetPostsOrderByCommentCount(string next);
    }
}
