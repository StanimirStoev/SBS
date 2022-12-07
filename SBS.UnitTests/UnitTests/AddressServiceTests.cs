using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.UnitTests.UnitTests
{
    public  class AddressServiceTests : UnitTestsBase
    {
        private IAddressService service;

        [SetUp]
        public void SetUp()
        {
            service = new AddressService(this.repo);
        }

        [Test]
        public async Task AddressService_Add_CanAddAddress()
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

            Guid cityId = Guid.NewGuid();
            City city = new City()
            {
                Id = cityId,
                Name = "test",
                CountryId= countryId,
                IsActive = true,
            };
            await repo.AddAsync<City>(city);
            await repo.SaveChangesAsync();

            AddressViewModel viewModel = new AddressViewModel()
            {
                AddressLine1 = "Line 1",
                AddressLine2 = "Line 2",
                CityId = cityId,
                CountryId = countryId,
                IsActive = true,
            };
            IEnumerable<AddressViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;

            //Act
            await this.service.Add(viewModel);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public async Task AddressService_Add_AddedAddressExists()
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

            Guid cityId = Guid.NewGuid();
            City city = new City()
            {
                Id = cityId,
                Name = "test",
                CountryId = countryId,
                IsActive = true,
            };
            await repo.AddAsync<City>(city);
            await repo.SaveChangesAsync();

            AddressViewModel viewModel = new AddressViewModel()
            {
                AddressLine1 = "Line 1",
                AddressLine2 = "Line 2",
                CityId = cityId,
                CountryId = countryId,
                IsActive = true,
            };

            //Act
            await this.service.Add(viewModel);
            IEnumerable<AddressViewModel> allUnits = await service.GetAll();

            //Assert
            Assert.IsTrue(allUnits.Any(u => u.AddressLine1 == viewModel.AddressLine1));
        }

        [Test]
        public async Task AddressService_Delete_CanDeleteAddress()
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

            Guid cityId = Guid.NewGuid();
            City city = new City()
            {
                Id = cityId,
                Name = "test",
                CountryId = countryId,
                IsActive = true,
            };
            await repo.AddAsync<City>(city);
            await repo.SaveChangesAsync();

            AddressViewModel viewModel = new AddressViewModel()
            {
                Id = id,
                AddressLine1 = "Line 1",
                AddressLine2 = "Line 2",
                CityId = cityId,
                CountryId = countryId,
                IsActive = true,
            };
            IEnumerable<AddressViewModel> all = await service.GetAll();
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
        public async Task AddressService_Delete_DeletedAddressNotExistsAsync()
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

            Guid cityId = Guid.NewGuid();
            City city = new City()
            {
                Id = cityId,
                Name = "test",
                CountryId = countryId,
                IsActive = true,
            };
            await repo.AddAsync<City>(city);
            await repo.SaveChangesAsync();

            AddressViewModel viewModel = new AddressViewModel()
            {
                Id= id,
                AddressLine1 = "Line 1",
                AddressLine2 = "Line 2",
                CityId = cityId,
                CountryId = countryId,
                IsActive = true,
            };

            this.service.Add(viewModel).Wait();

            var resultTask = service.GetAll();
            resultTask.Wait();
            List<AddressViewModel> all = resultTask.Result as List<AddressViewModel>;

            //Act
            viewModel = all.First(u => u.AddressLine1 == viewModel.AddressLine1);
            service.Delete(viewModel.Id).Wait();

            resultTask = service.GetAll();
            resultTask.Wait();
            all = resultTask.Result as List<AddressViewModel>;

            AddressViewModel viewModelResult = all.FirstOrDefault(u => u.Id == viewModel.Id);

            //Assert
            Assert.IsNull(viewModelResult);
        }

        [Test]
        public async Task AddressService_GetById_CanGetAddressById()
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

            Guid cityId = Guid.NewGuid();
            City city = new City()
            {
                Id = cityId,
                Name = "test",
                CountryId = countryId,
                IsActive = true,
            };
            await repo.AddAsync<City>(city);
            await repo.SaveChangesAsync();

            AddressViewModel viewModel = new AddressViewModel()
            {
                Id= id,
                AddressLine1 = "Line 1",
                AddressLine2 = "Line 2",
                CityId = cityId,
                CountryId = countryId,
                IsActive = true,
            };
            IEnumerable<AddressViewModel> all = await service.GetAll();
            await this.service.Add(viewModel);
            all = await service.GetAll();
            AddressViewModel viewModelData = all.First(u => u.AddressLine1 == viewModel.AddressLine1);

            //Act
            AddressViewModel viewModelResult = await service.Get(viewModelData.Id);

            //Assert
            Assert.IsNotNull(viewModelResult);
        }

        [Test]
        public async Task AddressService_GetAll_CanGetAllAddresss()
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

            Guid cityId = Guid.NewGuid();
            City city = new City()
            {
                Id = cityId,
                Name = "test",
                CountryId = countryId,
                IsActive = true,
            };
            await repo.AddAsync<City>(city);
            await repo.SaveChangesAsync();

            AddressViewModel viewModel = new AddressViewModel()
            {
                Id = id,
                AddressLine1 = "Line 1",
                AddressLine2 = "Line 2",
                CityId = cityId,
                CountryId = countryId,
                IsActive = true,
            };
            IEnumerable<AddressViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;
            await this.service.Add(viewModel);

            //Act
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task AddressService_Update_CanUpdateAddress()
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

            Guid cityId = Guid.NewGuid();
            City city = new City()
            {
                Id = cityId,
                Name = "test",
                CountryId = countryId,
                IsActive = true,
            };
            await repo.AddAsync<City>(city);
            await repo.SaveChangesAsync();

            AddressViewModel viewModel = new AddressViewModel()
            {
                Id = id,
                AddressLine1 = "Line 1",
                AddressLine2 = "Line 2",
                CityId = cityId,
                CountryId = countryId,
                IsActive = true,
            };
            await service.Add(viewModel);

            IEnumerable<AddressViewModel> all = await service.GetAll();
            AddressViewModel address = all.First();

            string oldAddressLine1 = address.AddressLine1;
            string oldAddressLine2 = address.AddressLine2;

            address.AddressLine1 = "AddressLine11";
            address.AddressLine2 = "AddressLine21";
            //Act
            await service.Update(address);
            AddressViewModel viewModelResult = all.First();

            //Assert
            Assert.That(viewModelResult.AddressLine1, Is.Not.EqualTo(oldAddressLine1));
            Assert.That(viewModelResult.AddressLine2, Is.Not.EqualTo(oldAddressLine2));
            Assert.That(address.AddressLine1, Is.EqualTo(viewModelResult.AddressLine1));
            Assert.That(address.AddressLine2, Is.EqualTo(viewModelResult.AddressLine2));
        }
    }
}
