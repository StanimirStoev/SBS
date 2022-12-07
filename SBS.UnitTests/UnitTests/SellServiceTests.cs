using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;

namespace SBS.UnitTests.UnitTests
{
    internal class SellServiceTests : UnitTestsBase
    {
        private ISellService service;

        [SetUp]
        public void SetUp()
        {
            service = new SellService(this.repo);
        }

        [Test]
        public async Task StoreService_Add_CanAddSell()
        {
            //Arrange
            Guid storeId = Guid.NewGuid();
            Guid deliveryDetId = Guid.NewGuid();
            Guid contragentId= Guid.NewGuid();

            Store store = new Store()
            {
                Id= storeId,
                Name = "Store",
                Description="store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            Contragent contargent = new Contragent()
            {
                Id = contragentId,
                FirstName = "FirstName",
                LastName = "LastName",
                VatNumber = "1234567890",
                IsClient= true,
                IsSupplier= true,
            };
            await repo.AddAsync<Contragent>(contargent);
            await repo.SaveChangesAsync();

            PartidesInStore part = new PartidesInStore()
            {
                DeliveryDetailId = deliveryDetId,
                StoreId = storeId,
                Qty = 10,
            };
            await repo.AddAsync<PartidesInStore>(part);
            await repo.SaveChangesAsync();

            SellViewModel viewModel = new SellViewModel()
            {
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                StoreId = storeId,
                IsActive = true,
            };
            viewModel.Details.Add(new SellDetailViewModel()
            {
                DeliveryDetailId = deliveryDetId,
                Price = 1,
                Qty = 1,
                IsActive = true,
                Sell = viewModel
            });

            IEnumerable<SellViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;

            //Act
            await this.service.Add(viewModel);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public async Task SellService_Add_AddedSellExists()
        {
            //Arrange
            Guid storeId = Guid.NewGuid();
            Guid deliveryDetId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            Contragent contargent = new Contragent()
            {
                Id = contragentId,
                FirstName = "FirstName",
                LastName = "LastName",
                VatNumber = "1234567890",
                IsClient = true,
                IsSupplier = true,
            };
            await repo.AddAsync<Contragent>(contargent);
            await repo.SaveChangesAsync();

            PartidesInStore part = new PartidesInStore()
            {
                DeliveryDetailId = deliveryDetId,
                StoreId = storeId,
                Qty = 10,
            };
            await repo.AddAsync<PartidesInStore>(part);
            await repo.SaveChangesAsync();

            SellViewModel viewModel = new SellViewModel()
            {
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                StoreId = storeId,
                IsActive = true,
            };
            viewModel.Details.Add(new SellDetailViewModel()
            {
                DeliveryDetailId = deliveryDetId,
                Price = 1,
                Qty = 1,
                IsActive = true,
                Sell = viewModel
            });

            //Act
            await this.service.Add(viewModel);
            IEnumerable<SellViewModel> allUnits = await service.GetAll();

            //Assert
            Assert.IsTrue(allUnits.Any());
        }

        [Test]
        public async Task SellService_Delete_CanDeleteSell()
        {
            //Arrange
            Guid storeId = Guid.NewGuid();
            Guid deliveryDetId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            Contragent contargent = new Contragent()
            {
                Id = contragentId,
                FirstName = "FirstName",
                LastName = "LastName",
                VatNumber = "1234567890",
                IsClient = true,
                IsSupplier = true,
            };
            await repo.AddAsync<Contragent>(contargent);
            await repo.SaveChangesAsync();

            PartidesInStore part = new PartidesInStore()
            {
                DeliveryDetailId = deliveryDetId,
                StoreId = storeId,
                Qty = 10,
            };
            await repo.AddAsync<PartidesInStore>(part);
            await repo.SaveChangesAsync();

            SellViewModel viewModel = new SellViewModel()
            {
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                StoreId = storeId,
                IsActive = true,
            };
            viewModel.Details.Add(new SellDetailViewModel()
            {
                DeliveryDetailId = deliveryDetId,
                Price = 1,
                Qty = 1,
                IsActive = true,
                Sell = viewModel
            });

            IEnumerable<SellViewModel> allUnits = await service.GetAll();
            int expected = allUnits.Count();

            await this.service.Add(viewModel);

            allUnits = await service.GetAll();
            Guid id = allUnits.First().Id;

            //Act
            await service.Delete(id);
            allUnits = await service.GetAll();
            int actual = allUnits.Count();

            //Assert
            // Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task SellService_Delete_DeletedSellNotExistsAsync()
        {
            //Arrange
            Guid storeId = Guid.NewGuid();
            Guid deliveryDetId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            Contragent contargent = new Contragent()
            {
                Id = contragentId,
                FirstName = "FirstName",
                LastName = "LastName",
                VatNumber = "1234567890",
                IsClient = true,
                IsSupplier = true,
            };
            await repo.AddAsync<Contragent>(contargent);
            await repo.SaveChangesAsync();

            PartidesInStore part = new PartidesInStore()
            {
                DeliveryDetailId = deliveryDetId,
                StoreId = storeId,
                Qty = 10,
            };
            await repo.AddAsync<PartidesInStore>(part);
            await repo.SaveChangesAsync();

            SellViewModel viewModel = new SellViewModel()
            {
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                StoreId = storeId,
                IsActive = true,
            };
            viewModel.Details.Add(new SellDetailViewModel()
            {
                DeliveryDetailId = deliveryDetId,
                Price = 1,
                Qty = 1,
                IsActive = true,
                Sell = viewModel
            });

            this.service.Add(viewModel).Wait();

            var resultTask = service.GetAll();
            resultTask.Wait();
            List<SellViewModel> allUnits = resultTask.Result as List<SellViewModel>;

            //Act
            viewModel = allUnits[0];
            service.Delete(viewModel.Id).Wait();

            resultTask = service.GetAll();
            resultTask.Wait();
            allUnits = resultTask.Result as List<SellViewModel>;

            SellViewModel viewModelResult = allUnits.FirstOrDefault(u => u.Id == viewModel.Id);

            //Assert
            Assert.IsNull(viewModelResult);
        }

        [Test]
        public async Task SellService_GetById_CanGetSellById()
        {
            //Arrange
            Guid storeId = Guid.NewGuid();
            Guid deliveryDetId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            Contragent contargent = new Contragent()
            {
                Id = contragentId,
                FirstName = "FirstName",
                LastName = "LastName",
                VatNumber = "1234567890",
                IsClient = true,
                IsSupplier = true,
            };
            await repo.AddAsync<Contragent>(contargent);
            await repo.SaveChangesAsync();

            PartidesInStore part = new PartidesInStore()
            {
                DeliveryDetailId = deliveryDetId,
                StoreId = storeId,
                Qty = 10,
            };
            await repo.AddAsync<PartidesInStore>(part);
            await repo.SaveChangesAsync();

            SellViewModel viewModel = new SellViewModel()
            {
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                StoreId = storeId,
                IsActive = true,
            };
            viewModel.Details.Add(new SellDetailViewModel()
            {
                DeliveryDetailId = deliveryDetId,
                Price = 1,
                Qty = 1,
                IsActive = true,
                Sell = viewModel
            });

            this.service.Add(viewModel).Wait();
            IEnumerable<SellViewModel> all = await service.GetAll();
            await this.service.Add(viewModel);
            all = await service.GetAll();
            SellViewModel viewModelData = all.First();

            //Act
            SellViewModel viewModelResult = await service.Get(viewModelData.Id);

            //Assert
            Assert.IsNotNull(viewModelResult);
        }

        [Test]
        public async Task StoreService_Update_CanUpdateStore()
        {
            //Arrange
            Guid storeId = Guid.NewGuid();
            Guid deliveryDetId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            Contragent contargent = new Contragent()
            {
                Id = contragentId,
                FirstName = "FirstName",
                LastName = "LastName",
                VatNumber = "1234567890",
                IsClient = true,
                IsSupplier = true,
            };
            await repo.AddAsync<Contragent>(contargent);
            await repo.SaveChangesAsync();

            PartidesInStore part = new PartidesInStore()
            {
                DeliveryDetailId = deliveryDetId,
                StoreId = storeId,
                Qty = 10,
            };
            await repo.AddAsync<PartidesInStore>(part);
            await repo.SaveChangesAsync();

            SellViewModel viewModel = new SellViewModel()
            {
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                StoreId = storeId,
                IsActive = true,
            };
            viewModel.Details.Add(new SellDetailViewModel()
            {
                DeliveryDetailId = deliveryDetId,
                Price = 1,
                Qty = 1,
                IsActive = true,
                Sell = viewModel
            });

            this.service.Add(viewModel).Wait();

            IEnumerable<SellViewModel> all = await service.GetAll();

            SellViewModel model = all.First();
            Guid id = viewModel.Id;
            double oldTotal = model.SellTotalPrice;
            DateTime? oldDat = model.CreateDatetime;

            model.Details[0].Price = 10;
            model.CreateDatetime = DateTime.Now.AddDays(10);

            //Act
            await service.Update(model);
            SellViewModel viewModelResult = all.First();

            //Assert
            Assert.That(viewModelResult.SellTotalPrice, Is.Not.EqualTo(oldTotal));
            Assert.That(viewModelResult.CreateDatetime, Is.Not.EqualTo(oldDat));
            Assert.That(model.SellTotalPrice, Is.EqualTo(viewModelResult.SellTotalPrice));
            Assert.That(model.CreateDatetime, Is.EqualTo(viewModelResult.CreateDatetime));
        }
    }
}
