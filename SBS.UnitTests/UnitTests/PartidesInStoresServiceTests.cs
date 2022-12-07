using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;

namespace SBS.UnitTests.UnitTests
{
    public class PartidesInStoresServiceTests : UnitTestsBase
    {
        private IPartidesInStoresService service;

        [SetUp]
        public void SetUp()
        {
            service = new PartidesInStoresService(this.repo);
        }

        [Test]
        public async Task PartidesInStoresService_GetAll_CanGetAllPartidesInStores()
        {
            //Arrange
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
                IsActive= true,
            };
            await repo.AddAsync<Unit>(unit);
            await repo.SaveChangesAsync();

            Guid articleId = Guid.NewGuid();
            Article article = new Article()
            {
                Id = articleId,
                Name = "Article",
                Description = "article desc",
                IsActive= true,
                Model = "asd234",
                Title= "Title",
                UnitId = unitId,
                
            };
            await repo.AddAsync<Article>(article);
            await repo.SaveChangesAsync();

            Guid contragentId = Guid.NewGuid();

            Guid deliveryDetId = Guid.NewGuid();
            DeliveryDetail delDet = new DeliveryDetail()
            {
                Id = deliveryDetId,
                ArticleId = articleId,
                DeliveryId = deliveryDetId,
                Price = 12.5,
                IsActive = true,
                Qty = 10,
            };
            await repo.AddAsync<DeliveryDetail>(delDet);
            await repo.SaveChangesAsync();

            Guid deliveryId = Guid.NewGuid();
            Delivery delivery = new Delivery()
            {
                Id = deliveryId,
                ContragentId = contragentId,
                IsActive = true,
                IsConfirmed = true,
                StoreId = storeId,
            };
            delivery.Details.Add(delDet);
            await repo.AddAsync<Delivery>(delivery);
            await repo.SaveChangesAsync();

            PartidesInStore part = new PartidesInStore()
            {
                DeliveryDetailId = deliveryDetId,
                StoreId = storeId,
                Qty = 10,
            };
            await repo.AddAsync<PartidesInStore>(part);
            await repo.SaveChangesAsync();


            int expected = 1;

            //Act
            IEnumerable<PartidesInStoreViewModel> all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
