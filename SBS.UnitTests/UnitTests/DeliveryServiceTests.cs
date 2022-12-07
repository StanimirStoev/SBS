using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;

namespace SBS.UnitTests.UnitTests
{
    internal class DeliveryServiceTests : UnitTestsBase
    {
        private IDeliveryService service;

        [SetUp]
        public void SetUp()
        {
            service = new DeliveryService(this.repo);
        }

        [Test]
        public async Task DeliveryService_Add_CanAddDelivery()
        {
            //Arrange
            Guid deliveryId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

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

            Guid storeId = Guid.NewGuid();
            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            DeliveryViewModel viewModel = new DeliveryViewModel()
            {
                Id = deliveryId,
                ContragentId= contragentId,
                CreateDatetime= DateTime.Now,
                IsConfirmed= false,
                StoreId= storeId,
                IsActive= true,
            };

            IEnumerable<DeliveryViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;

            //Act
            await this.service.Add(viewModel);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task DeliveryService_Confirm_CanConfirmDelivery()
        {
            //Arrange
            Guid deliveryId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

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

            Guid storeId = Guid.NewGuid();
            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            DeliveryViewModel viewModel = new DeliveryViewModel()
            {
                Id = deliveryId,
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                IsConfirmed = false,
                StoreId = storeId,
                IsActive = true,
            };

            await this.service.Add(viewModel);

            IEnumerable<DeliveryViewModel> all = await service.GetAll();
            DeliveryViewModel deliveryModel = all.First();

            //Act
            await service.Confirm(deliveryModel);

            all = await service.GetAll();
            deliveryModel = all.First();

            //Assert
            Assert.IsTrue(deliveryModel.IsConfirmed);
        }

        [Test]
        public async Task DeliveryService_Delete_CanDeleteDelivery()
        {
            //Arrange
            Guid deliveryId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

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

            Guid storeId = Guid.NewGuid();
            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            DeliveryViewModel viewModel = new DeliveryViewModel()
            {
                Id = deliveryId,
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                IsConfirmed = false,
                StoreId = storeId,
                IsActive = true,
            };

            await this.service.Add(viewModel);
            IEnumerable<DeliveryViewModel> all = await service.GetAll();
            int expected = all.Count() - 1;

            //Act
            await service.Delete(deliveryId);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task DeliveryService_Get_CanGetDeliveryById()
        {
            //Arrange
            Guid deliveryId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

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

            Guid storeId = Guid.NewGuid();
            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            DeliveryViewModel viewModel = new DeliveryViewModel()
            {
                Id = deliveryId,
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                IsConfirmed = false,
                StoreId = storeId,
                IsActive = true,
            };

            await this.service.Add(viewModel);

            //Act
            DeliveryViewModel actual = await service.Get(deliveryId);

            //Assert
            Assert.That(viewModel.CreateDatetime, Is.EqualTo(actual.CreateDatetime));
            Assert.That(viewModel.ContragentId, Is.EqualTo(actual.ContragentId));
            Assert.That(viewModel.IsConfirmed, Is.EqualTo(actual.IsConfirmed));
            Assert.That(viewModel.StoreId, Is.EqualTo(actual.StoreId));

        }

        [Test]
        public async Task DeliveryService_GetPartide_CanPartide()
        {
            //Arrange
            Guid deliveryId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

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

            Guid storeId = Guid.NewGuid();
            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            Guid unitId = Guid.NewGuid();
            Unit unit = new Unit()
            {
                Id = unitId,
                Name = "Unit",
                Description = "unit desc",
                IsActive = true,
            };
            await repo.AddAsync<Unit>(unit);
            await repo.SaveChangesAsync();

            Guid articleId = Guid.NewGuid();
            Article article = new Article()
            {
                Id = articleId,
                Name = "Article",
                Description = "article desc",
                IsActive = true,
                Model = "asd234",
                Title = "Title",
                UnitId = unitId,

            };
            await repo.AddAsync<Article>(article);
            await repo.SaveChangesAsync();

            DeliveryViewModel viewModel = new DeliveryViewModel()
            {
                Id = deliveryId,
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                IsConfirmed = false,
                StoreId = storeId,
                IsActive = true,
            };
            Guid delDetId = Guid.NewGuid();
            viewModel.Details.Add(new DeliveryDetailViewModel()
            {
                Id= delDetId,
                ArticleId= articleId,
                DeliveryId= deliveryId,
                IsActive= true,
                Price = 5.5,
                Qty= 25,
                UnitId= unitId,
            });
            await this.service.Add(viewModel);

            //Act
            DeliveryDetailViewModel partide = await service.GetPartide(deliveryId);

            //Assert
            Assert.IsNotNull(partide);
        }

        [Test]
        public async Task DeliveryService_Update_CanUpdateDelivery()
        {
            //Arrange
            Guid deliveryId = Guid.NewGuid();
            Guid contragentId = Guid.NewGuid();

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

            Guid storeId = Guid.NewGuid();
            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };
            await repo.AddAsync<Store>(store);
            await repo.SaveChangesAsync();

            DeliveryViewModel viewModel = new DeliveryViewModel()
            {
                Id = deliveryId,
                ContragentId = contragentId,
                CreateDatetime = DateTime.Now,
                IsConfirmed = false,
                StoreId = storeId,
                IsActive = true,
            };
            await this.service.Add(viewModel);

            DeliveryViewModel oldDelivery = await service.Get(deliveryId);

            DateTime? oldDate = oldDelivery.CreateDatetime;
            Guid oldStoreId = oldDelivery.StoreId;
            Guid oldContragentId = oldDelivery.ContragentId;

            DateTime? newDate = oldDate.Value.AddDays(-10);
            Guid newStoreId = new Guid();
            Guid newContragentId = new Guid();

            //Act
            oldDelivery.StoreId = newStoreId;
            oldDelivery.ContragentId = newContragentId;

            await service.Update(oldDelivery);

            DeliveryViewModel actual = await service.Get(deliveryId);

            //Assert
            Assert.That(actual.ContragentId, Is.EqualTo(newContragentId));
            Assert.That(actual.StoreId, Is.EqualTo(newStoreId));

        }
    }
}
