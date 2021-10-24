using Imagegram.Application.Contracts.Persistence;
using Imagegram.Domain;

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
