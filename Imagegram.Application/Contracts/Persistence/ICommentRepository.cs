using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Application.Contracts.Persistence
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
    }
}
