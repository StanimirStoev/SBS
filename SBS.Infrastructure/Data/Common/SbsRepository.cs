namespace SBS.Infrastructure.Data.Common
{
    /// <summary>
    /// Repository access methods
    /// </summary>
    public class SbsRepository : Repository, ISbsRepository
    {
        /// <summary>
        /// Initialise Repository 
        /// </summary>
        /// <param name="context">Database context</param>
        public SbsRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
