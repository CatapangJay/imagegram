using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Application.Persistence.Contracts
{
    public interface ICommentRepository : IGenericRepository<Post>
    {
    }
}
