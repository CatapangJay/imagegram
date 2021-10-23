using Imagegram.Application.Persistence.Contracts;
using Imagegram.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagegram.Persistence.Repositories
{
    public class ImgramUserRepository : GenericRepository<ImgramUser>, IImgramUserRepository
    {
        private readonly ImagegramDbContext _dbContext;

        public ImgramUserRepository(ImagegramDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
