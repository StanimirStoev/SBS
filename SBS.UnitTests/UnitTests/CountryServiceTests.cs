using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;

namespace SBS.UnitTests.UnitTests
{
    public class CountryServiceTests : UnitTestsBase
    {
        private ICountryService service;

        [SetUp]
        public void SetUp()
        {
            service = new CountryService(this.repo);
        }

        [Test]
        public async Task CountryService_Add_CanAddCountry()
        {
            //Arrange
            CountryViewModel viewModel = new CountryViewModel()
            {
                Name = "test",
                Code= "aa",
                IsEu = true,
                IsActive = true,
            };
            IEnumerable<CountryViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;

            //Act
            await this.service.Add(viewModel);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            // Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public async Task CountryService_Add_AddedCountryExists()
        {
            //Arrange
            CountryViewModel viewModel = new CountryViewModel()
            {
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };

            //Act
            await this.service.Add(viewModel);
            IEnumerable<CountryViewModel> allUnits = await service.GetAll();

            //Assert
            Assert.IsTrue(allUnits.Any(u => u.Name == viewModel.Name && u.Code == viewModel.Code));
        }

        [Test]
        public async Task CountryService_Delete_CanDeleteCountry()
        {
            //Arrange
            Guid id = new Guid();
            CountryViewModel viewModel = new CountryViewModel()
            {
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            IEnumerable<CountryViewModel> all = await service.GetAll();
            int expected = all.Count();

            await this.service.Add(viewModel);
            all = await service.GetAll();
            id = all.First().Id;

            //Act
            await service.Delete(id);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            // Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CountryService_Delete_CountryStoreNotExists()
        {
            //Arrange
            CountryViewModel viewModel = new CountryViewModel()
            {
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };

            this.service.Add(viewModel).Wait();

            var resultTask = service.GetAll();
            resultTask.Wait();
            List<CountryViewModel> all = resultTask.Result as List<CountryViewModel>;

            //Act
            viewModel = all.First(u => u.Name == viewModel.Name && u.Code == viewModel.Code);
            service.Delete(viewModel.Id).Wait();

            resultTask = service.GetAll();
            resultTask.Wait();
            all = resultTask.Result as List<CountryViewModel>;

            CountryViewModel viewModelResult = all.FirstOrDefault(u => u.Id == viewModel.Id);

            //Assert
            Assert.IsNull(viewModelResult);
        }

        [Test]
        public async Task CountryService_GetById_CanGetCountryById()
        {
            //Arrange
            CountryViewModel viewModel = new CountryViewModel()
            {
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            IEnumerable<CountryViewModel> all = await service.GetAll();
            await this.service.Add(viewModel);
            all = await service.GetAll();
            CountryViewModel viewModelData = all.First(u => u.Name == viewModel.Name && u.Code == viewModel.Code);

            //Act
            CountryViewModel viewModelResult = await service.Get(viewModelData.Id);

            //Assert
            Assert.IsNotNull(viewModelResult);
        }

        [Test]
        public async Task CountryService_GetAll_CanGetAllCountries()
        {
            //Arrange
            CountryViewModel viewModel = new CountryViewModel()
            {
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            IEnumerable<CountryViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;
            await this.service.Add(viewModel);

            //Act
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task CountryService_Update_CanUpdateCountry()
        {
            //Arrange
            CountryViewModel itm = new CountryViewModel()
            {
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            await service.Add(itm);

            IEnumerable<CountryViewModel> all = await service.GetAll();
            CountryViewModel viewModel = all.First();
            Guid id = viewModel.Id;
            string oldName = viewModel.Name;
            string oldCode = viewModel.Code;

            viewModel.Name = "test1";
            viewModel.Code = "BB1";

            //Act
            await service.Update(viewModel);
            CountryViewModel viewModelResult = all.First();

            //Assert
            Assert.That(viewModelResult.Name, Is.Not.EqualTo(oldName));
            Assert.That(viewModelResult.Code, Is.Not.EqualTo(oldCode));
            Assert.That(viewModel.Name, Is.EqualTo(viewModelResult.Name));
            Assert.That(viewModel.Code, Is.EqualTo(viewModelResult.Code));
        }
    }
}
