using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;

namespace SBS.UnitTests.UnitTests
{
    public class ContragentServiceTests : UnitTestsBase
    {
        private IContragentService service;

        [SetUp]
        public void SetUp()
        {
            service = new ContragentService(this.repo);
        }

        [Test]
        public async Task ContragentService_Add_CanAddContragent()
        {
            //Arrange
            ContragentViewModel viewModel = new ContragentViewModel()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                VatNumber = "1234567890",
                IsActive = true,
            };
            IEnumerable<ContragentViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;

            //Act
            await this.service.Add(viewModel);
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public async Task ContragentService_Add_AddedContragentExists()
        {
            //Arrange
            ContragentViewModel viewModel = new ContragentViewModel()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                VatNumber = "1234567890",
                IsActive = true,
            };

            //Act
            await this.service.Add(viewModel);
            IEnumerable<ContragentViewModel> allUnits = await service.GetAll();

            //Assert
            Assert.IsTrue(allUnits.Any(u => u.FirstName == viewModel.FirstName && u.LastName == viewModel.LastName));
        }

        [Test]
        public async Task ContragentService_Delete_CanDeleteContragent()
        {
            //Arrange
            Guid id = new Guid();
            ContragentViewModel viewModel = new ContragentViewModel()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                VatNumber = "1234567890",
                IsActive = true,
            };
            IEnumerable<ContragentViewModel> all = await service.GetAll();
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
        public void ContragentService_Delete_DeletedContragentNotExists()
        {
            //Arrange
            ContragentViewModel viewModel = new ContragentViewModel()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                VatNumber = "1234567890",
                IsActive = true,
            };

            this.service.Add(viewModel).Wait();

            var resultTask = service.GetAll();
            resultTask.Wait();
            List<ContragentViewModel> all = resultTask.Result as List<ContragentViewModel>;

            //Act
            viewModel = all.First(u => u.FirstName == viewModel.FirstName && u.LastName == viewModel.LastName);
            service.Delete(viewModel.Id).Wait();

            resultTask = service.GetAll();
            resultTask.Wait();
            all = resultTask.Result as List<ContragentViewModel>;

            ContragentViewModel viewModelResult = all.FirstOrDefault(u => u.Id == viewModel.Id);

            //Assert
            Assert.IsNull(viewModelResult);
        }

        [Test]
        public async Task ContragentService_GetById_CanGetContragentById()
        {
            //Arrange
            ContragentViewModel viewModel = new ContragentViewModel()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                VatNumber = "1234567890",
                IsActive = true,
            };
            IEnumerable<ContragentViewModel> all = await service.GetAll();
            await this.service.Add(viewModel);
            all = await service.GetAll();
            ContragentViewModel viewModelData = all.First(u => u.FirstName == viewModel.FirstName && u.LastName == viewModel.LastName);

            //Act
            ContragentViewModel viewModelResult = await service.Get(viewModelData.Id);

            //Assert
            Assert.IsNotNull(viewModelResult);
        }

        [Test]
        public async Task ContragentService_GetAll_CanGetAllContragents()
        {
            //Arrange
            ContragentViewModel viewModel = new ContragentViewModel()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                VatNumber = "1234567890",
                IsActive = true,
            };
            IEnumerable<ContragentViewModel> all = await service.GetAll();
            int expected = all.Count() + 1;
            await this.service.Add(viewModel);

            //Act
            all = await service.GetAll();
            int actual = all.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task ContragentService_Update_CanUpdateContragent()
        {
            //Arrange
            ContragentViewModel itm = new ContragentViewModel()
            {
                FirstName = "First Name",
                LastName = "Last Name",
                VatNumber = "1234567890",
                IsActive = true,
            };
            await service.Add(itm);

            IEnumerable<ContragentViewModel> all = await service.GetAll();
            ContragentViewModel viewModel = all.First();
            Guid id = viewModel.Id;
            string oldFirstName = viewModel.FirstName;
            string oldLastName = viewModel.LastName;

            viewModel.FirstName = "test1";
            viewModel.LastName = "9994567890";

            //Act
            await service.Update(viewModel);
            ContragentViewModel viewModelResult = all.First();

            //Assert
            Assert.That(viewModelResult.FirstName, Is.Not.EqualTo(oldFirstName));
            Assert.That(viewModelResult.LastName, Is.Not.EqualTo(oldLastName));
            Assert.That(viewModel.FirstName, Is.EqualTo(viewModelResult.FirstName));
            Assert.That(viewModel.LastName, Is.EqualTo(viewModelResult.LastName));
        }
    }
}
