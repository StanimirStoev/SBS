using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.UnitTests.UnitTests
{
    public class CityServiceTests : UnitTestsBase
    {
        private ICityService service;

        [SetUp]
        public void SetUp()
        {
            service = new CityService(this.repo);
        }

        [Test]
        public async Task CityService_Add_CanAddCity()
        {
            //Arrange
            Guid countryId= Guid.NewGuid();
            Country country = new Country()
            {
                Id= countryId,
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            await repo.AddAsync<Country>(country);
            await repo.SaveChangesAsync();

            CityViewModel viewModel = new CityViewModel()
            {
                Name = "Name",
                CountryId = countryId,
                IsActive = true,
            };
            IEnumerable<CityViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;

            //Act
            await this.service.Add(viewModel);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public async Task CityService_Add_AddedCityExists()
        {
            //Arrange
            Guid countryId = Guid.NewGuid();
            Country country = new Country()
            {
                Id = countryId,
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            await repo.AddAsync<Country>(country);
            await repo.SaveChangesAsync();

            CityViewModel viewModel = new CityViewModel()
            {
                Name = "Name",
                CountryId = countryId,
                IsActive = true,
            };

            //Act
            await this.service.Add(viewModel);
            IEnumerable<CityViewModel> allUnits = await service.GetAll();

            //Assert
            Assert.IsTrue(allUnits.Any(u => u.Name == viewModel.Name));
        }

        [Test]
        public async Task CityService_Delete_CanDeleteCity()
        {
            //Arrange
            Guid id = new Guid();
            Guid countryId = Guid.NewGuid();
            Country country = new Country()
            {
                Id = countryId,
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            await repo.AddAsync<Country>(country);
            await repo.SaveChangesAsync();

            CityViewModel viewModel = new CityViewModel()
            {
                Id= id,
                Name = "Name",
                CountryId = countryId,
                IsActive = true,
            };
            IEnumerable<CityViewModel> all = await service.GetAll();
            int expected = all.Count();

            await this.service.Add(viewModel);
            all = await service.GetAll();
            id = all.First().Id;

            //Act
            await service.Delete(id);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task CityService_Delete_DeletedCityNotExistsAsync()
        {
            //Arrange
            Guid id = new Guid();
            Guid countryId = Guid.NewGuid();
            Country country = new Country()
            {
                Id = countryId,
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            await repo.AddAsync<Country>(country);
            await repo.SaveChangesAsync();

            CityViewModel viewModel = new CityViewModel()
            {
                Id = id,
                Name = "Name",
                CountryId = countryId,
                IsActive = true,
            };

            this.service.Add(viewModel).Wait();

            var resultTask = service.GetAll();
            resultTask.Wait();
            List<CityViewModel> all = resultTask.Result as List<CityViewModel>;

            //Act
            viewModel = all.First(u => u.Name == viewModel.Name);
            service.Delete(viewModel.Id).Wait();

            resultTask = service.GetAll();
            resultTask.Wait();
            all = resultTask.Result as List<CityViewModel>;

            CityViewModel viewModelResult = all.FirstOrDefault(u => u.Id == viewModel.Id);

            //Assert
            Assert.IsNull(viewModelResult);
        }

        [Test]
        public async Task CityService_GetById_CanGetCityById()
        {
            //Arrange
            Guid id = new Guid();
            Guid countryId = Guid.NewGuid();
            Country country = new Country()
            {
                Id = countryId,
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            await repo.AddAsync<Country>(country);
            await repo.SaveChangesAsync();

            CityViewModel viewModel = new CityViewModel()
            {
                Id = id,
                Name = "Name",
                CountryId = countryId,
                IsActive = true,
            };
            IEnumerable<CityViewModel> all = await service.GetAll();
            await this.service.Add(viewModel);
            all = await service.GetAll();
            CityViewModel viewModelData = all.First(u => u.Name == viewModel.Name);

            //Act
            CityViewModel viewModelResult = await service.Get(viewModelData.Id);

            //Assert
            Assert.IsNotNull(viewModelResult);
        }

        [Test]
        public async Task CityService_GetAll_CanGetAllCitys()
        {
            //Arrange
            Guid id = new Guid();
            Guid countryId = Guid.NewGuid();
            Country country = new Country()
            {
                Id = countryId,
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            await repo.AddAsync<Country>(country);
            await repo.SaveChangesAsync();

            CityViewModel viewModel = new CityViewModel()
            {
                Id = id,
                Name = "Name",
                CountryId = countryId,
                IsActive = true,
            };
            IEnumerable<CityViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;
            await this.service.Add(viewModel);

            //Act
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task CityService_Update_CanUpdateCity()
        {
            //Arrange
            Guid id = new Guid();
            Guid countryId = Guid.NewGuid();
            Country country = new Country()
            {
                Id = countryId,
                Name = "test",
                Code = "aa",
                IsEu = true,
                IsActive = true,
            };
            await repo.AddAsync<Country>(country);
            await repo.SaveChangesAsync();

            CityViewModel viewModel = new CityViewModel()
            {
                Id = id,
                Name = "Name",
                CountryId = countryId,
                IsActive = true,
            };
            await service.Add(viewModel);

            IEnumerable<CityViewModel> all = await service.GetAll();
            CityViewModel city = all.First();

            string oldFirstName = city.Name;

            city.Name = "test1";

            //Act
            await service.Update(city);
            CityViewModel viewModelResult = all.First();

            //Assert
            Assert.That(viewModelResult.Name, Is.Not.EqualTo(oldFirstName));
            Assert.That(city.Name, Is.EqualTo(viewModelResult.Name));
        }
    }
}
