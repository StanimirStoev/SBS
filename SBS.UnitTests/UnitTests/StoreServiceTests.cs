using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;

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
        public async Task StoreService_Delete_CanDeleteStore()
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
        public void StoreService_Delete_DeletedStoreNotExists()
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

        [Test]
        public async Task StoreService_GetAll_CanGetAllStores()
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
            await this.service.Add(viewModel);

            //Act
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task StoreService_GetAll_CanGetAllStoresExclude()
        {
            //Arrange
            StoreViewModel viewModel = new StoreViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            StoreViewModel viewModel1 = new StoreViewModel()
            {
                Name = "test1",
                Description = "Test1",
                IsActive = true,
            };
            StoreViewModel viewModel2 = new StoreViewModel()
            {
                Name = "test2",
                Description = "Test2",
                IsActive = true,
            };
            
            await this.service.Add(viewModel);
            await this.service.Add(viewModel1);
            await this.service.Add(viewModel2);

            IEnumerable<StoreViewModel> all = await service.GetAll();
            StoreViewModel itm = all.First(u => u.Name == viewModel.Name && u.Description == viewModel.Description);
            //Act
            IEnumerable<StoreViewModel>  result = await service.GetAllExcluded(itm.Id);
            StoreViewModel? res = result.FirstOrDefault(s => s.Id == itm.Id);

            //Assert
            Assert.IsNull(res);
        }

        [Test]
        public async Task StoreService_Update_CanUpdateStore()
        {
            //Arrange
            StoreViewModel itm = new StoreViewModel()
            {
                Name = "testOrigin",
                Description = "TestOrigin",
                IsActive = true,
            };
            await service.Add(itm);

            IEnumerable<StoreViewModel> all = await service.GetAll();
            StoreViewModel viewModel = all.First();
            Guid id = viewModel.Id;
            string oldName = viewModel.Name;
            string oldDescription = viewModel.Description;

            viewModel.Name = "test";
            viewModel.Description = "Test";

            //Act
            await service.Update(viewModel);
            StoreViewModel viewModelResult = all.First();

            //Assert
            Assert.That(viewModelResult.Name, Is.Not.EqualTo(oldName));
            Assert.That(viewModelResult.Description, Is.Not.EqualTo(oldDescription));
            Assert.That(viewModel.Name, Is.EqualTo(viewModelResult.Name));
            Assert.That(viewModel.Description, Is.EqualTo(viewModelResult.Description));
        }

        [Test]
        public async Task StoreService_GetAllNonEmpty_CanGetAllNonEmpty()
        {
            //Arrange
            StoreViewModel viewModel = new StoreViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            StoreViewModel viewModel1 = new StoreViewModel()
            {
                Name = "test1",
                Description = "Test1",
                IsActive = true,
            };
            StoreViewModel viewModel2 = new StoreViewModel()
            {
                Name = "test2",
                Description = "Test2",
                IsActive = true,
            };

            await this.service.Add(viewModel);
            await this.service.Add(viewModel1);
            await this.service.Add(viewModel2);

            IEnumerable<StoreViewModel> all = await service.GetAll();
            StoreViewModel itm = all.First(u => u.Name == viewModel.Name && u.Description == viewModel.Description);

            DeliveryDetail det = new DeliveryDetail()
            {
                Id = new Guid(),
                DeliveryId = new Guid(),
                Price = 1.1,
                Qty = 10.4,
                IsActive = true,
            };
            PartidesInStore part = new PartidesInStore()
            {
                StoreId = itm.Id,
                DeliveryDetail = det,
                Qty = 10.4,
            };
            await repo.AddAsync<DeliveryDetail>(det);
            await repo.AddAsync<PartidesInStore>(part);
            await repo.SaveChangesAsync();

            //Act
            IEnumerable<StoreViewModel> result = await service.GetAllNotEmpty();
            StoreViewModel? res = result.FirstOrDefault(s => s.Id == itm.Id);

            //Assert
            Assert.That(res.Id, Is.EqualTo(itm.Id));
        }
    }
}
