using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;

namespace SBS.UnitTests.UnitTests
{
    internal class ArticleServiceTests : UnitTestsBase
    {
        private IArticleService service;

        [SetUp]
        public void SetUp()
        {
            service = new ArticleService(this.repo);
        }

        [Test]
        public async Task ArticleService_Add_CanAddArticle()
        {
            //Arrange
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

            ArticleViewModel viewModel = new ArticleViewModel()
            {
                Name = "Name",
                UnitId = unitId,
                IsActive = true,
            };
            IEnumerable<ArticleViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;

            //Act
            await this.service.Add(viewModel);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public async Task ArticleService_Add_AddedArticleExists()
        {
            //Arrange
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

            ArticleViewModel viewModel = new ArticleViewModel()
            {
                Name = "Name",
                UnitId = unitId,
                IsActive = true,
            };

            //Act
            await this.service.Add(viewModel);
            IEnumerable<ArticleViewModel> allUnits = await service.GetAll();

            //Assert
            Assert.IsTrue(allUnits.Any(u => u.Name == viewModel.Name));
        }

        [Test]
        public async Task ArticleService_Delete_CanDeleteArticle()
        {
            //Arrange
            Guid id = new Guid();
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

            ArticleViewModel viewModel = new ArticleViewModel()
            {
                Id = id,
                Name = "Name",
                UnitId = unitId,
                IsActive = true,
            };
            IEnumerable<ArticleViewModel> all = await service.GetAll();
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
        public async Task ArticleService_Delete_DeletedArticleNotExistsAsync()
        {
            //Arrange
            Guid id = new Guid();
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

            ArticleViewModel viewModel = new ArticleViewModel()
            {
                Id = id,
                Name = "Name",
                UnitId = unitId,
                IsActive = true,
            };

            this.service.Add(viewModel).Wait();

            var resultTask = service.GetAll();
            resultTask.Wait();
            List<ArticleViewModel> all = resultTask.Result as List<ArticleViewModel>;

            //Act
            viewModel = all.First(u => u.Name == viewModel.Name);
            service.Delete(viewModel.Id).Wait();

            resultTask = service.GetAll();
            resultTask.Wait();
            all = resultTask.Result as List<ArticleViewModel>;

            ArticleViewModel viewModelResult = all.FirstOrDefault(u => u.Id == viewModel.Id);

            //Assert
            Assert.IsNull(viewModelResult);
        }

        [Test]
        public async Task ArticleService_GetById_CanGetArticleById()
        {
            //Arrange
            Guid id = new Guid();
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

            ArticleViewModel viewModel = new ArticleViewModel()
            {
                Id = id,
                Name = "Name",
                UnitId = unitId,
                IsActive = true,
            };
            IEnumerable<ArticleViewModel> all = await service.GetAll();
            await this.service.Add(viewModel);
            all = await service.GetAll();
            ArticleViewModel viewModelData = all.First(u => u.Name == viewModel.Name);

            //Act
            ArticleViewModel viewModelResult = await service.Get(viewModelData.Id);

            //Assert
            Assert.IsNotNull(viewModelResult);
        }

        [Test]
        public async Task ArticleService_GetAll_CanGetAllArticles()
        {
            //Arrange
            Guid id = new Guid();
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

            ArticleViewModel viewModel = new ArticleViewModel()
            {
                Id = id,
                Name = "Name",
                UnitId = unitId,
                IsActive = true,
            };
            IEnumerable<ArticleViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;
            await this.service.Add(viewModel);

            //Act
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task ArticleService_Update_CanUpdateArticle()
        {
            //Arrange
            Guid id = new Guid();
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

            ArticleViewModel viewModel = new ArticleViewModel()
            {
                Id = id,
                Name = "Name",
                UnitId = unitId,
                IsActive = true,
            };
            await service.Add(viewModel);

            IEnumerable<ArticleViewModel> all = await service.GetAll();
            ArticleViewModel city = all.First();

            string oldFirstName = city.Name;

            city.Name = "test1";

            //Act
            await service.Update(city);
            ArticleViewModel viewModelResult = all.First();

            //Assert
            Assert.That(viewModelResult.Name, Is.Not.EqualTo(oldFirstName));
            Assert.That(city.Name, Is.EqualTo(viewModelResult.Name));
        }
    }
}
