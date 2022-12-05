using Microsoft.EntityFrameworkCore;
using SBS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.UnitTests.Mocks
{
    public static class DatabaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                 var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("SbsDbInMemory" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new ApplicationDbContext(dbContextOptions, false);
            }
        }
    }
}
