using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
