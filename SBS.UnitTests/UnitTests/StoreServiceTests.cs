using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.UnitTests.UnitTests
{
    public class StoreServiceTests : UnitTestsBase
    {
        private IStoreService service;

        [SetUp]
        public void SetUp()
        {
            service = new StoreService(this.repo);
        }

        [Test]
        public async Task StoreService_Add_CanAddStore()
        {
            //Arrange
            StoreViewModel viewModel = new StoreViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            IEnumerable<StoreViewModel> all = await service.GetAll();
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
        public async Task StoreService_Add_AddedStoreExists()
        {
            //Arrange
            StoreViewModel viewModel = new StoreViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };

            //Act
            await this.service.Add(viewModel);
            IEnumerable<StoreViewModel> allUnits = await service.GetAll();

            //Assert
            Assert.IsTrue(allUnits.Any(u => u.Name == viewModel.Name && u.Description == viewModel.Description));
        }

        [Test]
        public async Task UnitService_Delete_CanDeleteUnit()
        {
            //Arrange
            Guid id = new Guid();
            StoreViewModel viewModel = new StoreViewModel()
            {
                Id = id,
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            IEnumerable<StoreViewModel> allUnits = await service.GetAll();
            int expected = allUnits.Count();

            await this.service.Add(viewModel);
            allUnits = await service.GetAll();
            id = allUnits.First().Id;

            //Act
            await service.Delete(id);
            allUnits = await service.GetAll();
            int actual = allUnits.Count();

            //Assert
            // Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void UnitService_Delete_DeletedUnitNotExists()
        {
            //Arrange
            StoreViewModel viewModel = new StoreViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };

            this.service.Add(viewModel).Wait();

            var resultTask = service.GetAll();
            resultTask.Wait();
            List<StoreViewModel> allUnits = resultTask.Result as List<StoreViewModel>;

            //Act
            viewModel = allUnits.First(u => u.Name == viewModel.Name && u.Description == viewModel.Description);
            service.Delete(viewModel.Id).Wait();

            resultTask = service.GetAll();
            resultTask.Wait();
            allUnits = resultTask.Result as List<StoreViewModel>;

            StoreViewModel viewModelResult = allUnits.FirstOrDefault(u => u.Id == viewModel.Id);

            //Assert
            Assert.IsNull(viewModelResult);
        }

        [Test]
        public async Task StoreService_GetById_CanGetStoreById()
        {
            //Arrange
            StoreViewModel viewModel = new StoreViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            IEnumerable<StoreViewModel> all = await service.GetAll();
            await this.service.Add(viewModel);
            all = await service.GetAll();
            StoreViewModel viewModelData = all.First(u => u.Name == viewModel.Name && u.Description == viewModel.Description);

            //Act
            StoreViewModel viewModelResult = await service.Get(viewModelData.Id);

            //Assert
            Assert.IsNotNull(viewModelResult);
        }
    }
}
