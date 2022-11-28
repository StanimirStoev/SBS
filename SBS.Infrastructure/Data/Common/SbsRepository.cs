namespace SBS.Infrastructure.Data.Common
{
    public class SbsRepository : Repository, ISbsRepository
    {
        public SbsRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
