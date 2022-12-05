using SBS.Infrastructure.Data;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using SBS.Infrastructure.Data.Models.Account;
using SBS.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.UnitTests.UnitTests
{
    public class UnitTestsBase
    {
        protected ApplicationDbContext data;
        protected SbsRepository repo;

        [OneTimeSetUp] 
        public void SetUpBase() 
        {
            this.data = DatabaseMock.Instance;
            this.repo = new SbsRepository(data);
            this.SeedDatabase();
        }

        public ApplicationUser User { get; private set; }
        public Unit Unit { get; private set; }

        private void SeedDatabase()
        {
            this.User = new ApplicationUser()
            {
                Id = "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47",
                UserName = "Ники",
                NormalizedUserName = "Ники".ToUpper(),
                Email = "nikki@mail.com",
                NormalizedEmail = "nikki@mail.com".ToUpper(),
                FirstName = "Николета",
                LastName = "Добрева",
                EmailConfirmed = true,
            };

            this.Unit = new Unit()
            {
                Id = new Guid("a96f16ba-b522-4dd9-9ca6-7425fd7044f6"),
                Name = "pcs",
                Description = "Pieces",
                IsActive = true,
            };
        }

        [OneTimeTearDown] 
        public void TearDownBase() 
        { 
            this.data.Dispose();
        }
    }
}
