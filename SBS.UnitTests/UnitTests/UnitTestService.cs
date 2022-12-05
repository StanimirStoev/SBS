using SBS.Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBS.Core.Services;

namespace SBS.UnitTests.UnitTests
{
    [TestFixture]
    public class UnitTestService : UnitTestsBase
    {
        private IUnitService unitService;

        [OneTimeSetUp]
        public void SetUp()
        {
            unitService = new UnitService(this.repo);
        }
    }
}
