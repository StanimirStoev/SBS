using SBS.Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;
using SBS.Core.Models;

namespace SBS.UnitTests.UnitTests
{
    [TestFixture]
    public class UnitServiceTests : UnitTestsBase
    {
        private IUnitService unitService;

        [OneTimeSetUp]
        public void SetUp()
        {
            unitService = new UnitService(this.repo);
        }

        [Test]
        public async Task UnitService_Add_CanAddUnit()
        {
            //Arrange
            UnitViewModel viewModel = new UnitViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            List<UnitViewModel> allUnits = await unitService.GetAll();
            int expected = allUnits.Count() + 1;

            //Act
            await this.unitService.Add(viewModel);
            allUnits = await unitService.GetAll();
            int actual = allUnits.Count();

            //Assert
            // Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public async Task UnitService_Add_AddedUnitExists()
        {
            //Arrange
            UnitViewModel viewModel = new UnitViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };

            //Act
            await this.unitService.Add(viewModel);
            List<UnitViewModel> allUnits = await unitService.GetAll();

            //Assert
            Assert.IsTrue(allUnits.Any(u => u.Name == viewModel.Name && u.Description == viewModel.Description));
        }

        [Test]
        public async Task UnitService_Delete_CanDeleteUnit()
        {
            //Arrange
            UnitViewModel viewModel = new UnitViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            List<UnitViewModel> allUnits = await unitService.GetAll();
            int expected = allUnits.Count();

            //Act
            await this.unitService.Add(viewModel);
            viewModel = allUnits.First(u => u.Name == viewModel.Name && u.Description == viewModel.Description);
            await unitService.Delete(viewModel.Id);
            allUnits = await unitService.GetAll();
            int actual = allUnits.Count();

            //Assert
            // Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void UnitService_Delete_DeletedUnitNotExists()
        {
            //Arrange
            UnitViewModel viewModel = new UnitViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };

            this.unitService.Add(viewModel).Wait();

            var resultTask = unitService.GetAll();
            resultTask.Wait();
            List<UnitViewModel> allUnits = resultTask.Result as List<UnitViewModel>;

            //Act
            viewModel = allUnits.First(u => u.Name == viewModel.Name && u.Description == viewModel.Description);
            unitService.Delete(viewModel.Id).Wait();

            resultTask = unitService.GetAll();
            resultTask.Wait();
            allUnits = resultTask.Result as List<UnitViewModel>;

            UnitViewModel viewModelResult = allUnits.FirstOrDefault(u => u.Id == viewModel.Id);

            //Assert
            Assert.IsNull(viewModelResult);
        }

        [Test]
        public async Task UnitService_GetById_CanGetUnitById()
        {
            //Arrange
            UnitViewModel viewModel = new UnitViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            List<UnitViewModel> allUnits = await unitService.GetAll();
            await this.unitService.Add(viewModel);
            allUnits = await unitService.GetAll();
            UnitViewModel viewModelData = allUnits.First(u => u.Name == viewModel.Name && u.Description == viewModel.Description);

            //Act
            UnitViewModel viewModelResult = await unitService.Get(viewModelData.Id);

            //Assert
            Assert.IsNotNull(viewModelResult);
        }

        [Test]
        public async Task UnitService_GetAll_CanGetAllUnit()
        {
            //Arrange
            UnitViewModel viewModel = new UnitViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            List<UnitViewModel> allUnits = await unitService.GetAll();
            int expected = allUnits.Count() + 1;
            await this.unitService.Add(viewModel);

            //Act
            allUnits = await unitService.GetAll();
            int actual = allUnits.Count();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task UnitService_Update_CanUpdateUnit()
        {
            //Arrange
            List<UnitViewModel> allUnits = await unitService.GetAll();
            UnitViewModel viewModel = allUnits[0];
            Guid id = viewModel.Id;
            string oldName = viewModel.Name;
            string oldDescription = viewModel.Description;

            viewModel.Name = "test";
            viewModel.Description = "Test";

            //Act
            await unitService.Update(viewModel);
            UnitViewModel viewModelResult = allUnits[0];

            //Assert
            Assert.That(viewModelResult.Name, Is.Not.EqualTo(oldName));
            Assert.That(viewModelResult.Description, Is.Not.EqualTo(oldDescription));
            Assert.That(viewModel.Name, Is.EqualTo(viewModelResult.Name));
            Assert.That(viewModel.Description, Is.EqualTo(viewModelResult.Description));
        }

        [Test]
        public async Task UnitService_IsExistByName_CanCheckUnitExistByName()
        {
            //Arrange
            UnitViewModel viewModel = new UnitViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            await this.unitService.Add(viewModel);

            //Act
            bool exists = unitService.IsExists(viewModel.Name);

            //Assert
            Assert.IsTrue(exists);
        }
        [Test]
        public void UnitService_IsExistByName_CanCheckUnitNotExistByName()
        {
            //Arrange

            //Act
            bool exists = unitService.IsExists("UnexistedName");

            //Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task UnitService_IsExistByNameId_CanCheckUnitExistByNameId()
        {
            //Arrange
            UnitViewModel viewModel = new UnitViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            await this.unitService.Add(viewModel);

            //Act
            bool exists = unitService.IsExists(viewModel.Name, viewModel.Id);

            //Assert
            Assert.IsTrue(exists);
        }
        [Test]
        public async Task UnitService_IsExistByNameId_CanCheckUnitNotExistByNameId()
        {
            //Arrange
            UnitViewModel viewModel = new UnitViewModel()
            {
                Name = "test",
                Description = "Test",
                IsActive = true,
            };
            await this.unitService.Add(viewModel);
            List<UnitViewModel> allUnits = await unitService.GetAll();
            viewModel = allUnits.First(u => u.Name == viewModel.Name && u.Description == viewModel.Description);

            //Act
            bool notExists1 = unitService.IsExists("UnexistedName", viewModel.Id);
            bool exists = unitService.IsExists(viewModel.Name, new Guid());
            bool notExists3 = unitService.IsExists("UnexistedName", new Guid());
            bool notExists2 = unitService.IsExists(viewModel.Name, viewModel.Id);

            //Assert
            Assert.IsFalse(notExists1);
            Assert.IsTrue(exists);
            Assert.IsFalse(notExists2);
            Assert.IsFalse(notExists3);
        }
    }
}
