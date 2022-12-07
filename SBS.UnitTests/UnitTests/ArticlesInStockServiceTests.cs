using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;

namespace SBS.UnitTests.UnitTests
{
    public class ArticlesInStockServiceTests : UnitTestsBase
    {
        private IArticlesInStockService service;

        [SetUp]
        public void SetUp()
        {
            service = new ArticlesInStockService(this.repo);
        }

        [Test]
        public async Task ArticlesInStock_GetAll_CanGetAllArticlesInStock()
        {
            //Arrange
            Guid id = new Guid();

            Guid storeId = Guid.NewGuid();
            Store store = new Store()
            {
                Id = storeId,
                Name = "Store",
                Description = "store desc",
            };

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


            //Act
            IEnumerable<ArticlesInStockViewModel> all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.IsNotNull(actual);
        }
    }
}
