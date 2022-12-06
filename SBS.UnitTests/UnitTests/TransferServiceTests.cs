using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.UnitTests.UnitTests
{
    internal class TransferServiceTests : UnitTestsBase
    {
        private ITransferService service;

        [SetUp]
        public void SetUp()
        {
            service = new TransferService(this.repo);
        }

        [Test]
        public async Task TransferService_Add_CanAddTransfer()
        {
            //Arrange
            Guid delivDetId = Guid.NewGuid();
            PartidesInStore fromPartInStore = new PartidesInStore()
            {
                DeliveryDetailId = delivDetId,
                Qty = 50.8,
                StoreId = Guid.NewGuid(),
            };
            await repo.AddAsync<PartidesInStore>(fromPartInStore);

            PartidesInStore toPartInStore = new PartidesInStore()
            {
                DeliveryDetailId = delivDetId,
                Qty = 20.2,
                StoreId = Guid.NewGuid(),
            };
            await repo.AddAsync<PartidesInStore>(toPartInStore);

            await repo.SaveChangesAsync();

            TransferViewModel viewModel = new TransferViewModel()
            {
                CreateDatetime= DateTime.Now,
                FromStoreId = fromPartInStore.StoreId,
                ToStoreId = toPartInStore.StoreId,
                IsActive = true,
            };
            viewModel.Details.Add(new TransferDetailViewModel()
            {
                DeliveryDetailId = delivDetId,
                IsActive = true,
                Qty = 10.3,
                Transfer = viewModel
            });
            IEnumerable<TransferViewModel> allUnits = await service.GetAll();
            int expected = allUnits.Count() + 1;

            //Act
            await this.service.Add(viewModel);
            await repo.SaveChangesAsync();
            int actual = repo.All<Transfer>().Count();

            //Assert
            // Assert.AreEqual(expected, actual);
            Debug.WriteLine($"{actual} {expected}");
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public async Task TransferService_Add_AddedTransferExists()
        {
            //Arrange
            Guid delivDetId = Guid.NewGuid();
            PartidesInStore fromPartInStore = new PartidesInStore()
            {
                DeliveryDetailId = delivDetId,
                Qty = 50.8,
                StoreId = Guid.NewGuid(),
            };
            await repo.AddAsync<PartidesInStore>(fromPartInStore);

            PartidesInStore toPartInStore = new PartidesInStore()
            {
                DeliveryDetailId = delivDetId,
                Qty = 20.2,
                StoreId = Guid.NewGuid(),
            };
            await repo.AddAsync<PartidesInStore>(toPartInStore);

            await repo.SaveChangesAsync();

            TransferViewModel viewModel = new TransferViewModel()
            {
                CreateDatetime = DateTime.Now,
                FromStoreId = fromPartInStore.StoreId,
                ToStoreId = toPartInStore.StoreId,
                IsActive = true,
            };
            viewModel.Details.Add(new TransferDetailViewModel()
            {
                DeliveryDetailId = delivDetId,
                IsActive = true,
                Qty = 10.3,
                Transfer = viewModel
            });
            IEnumerable<TransferViewModel> allUnits = await service.GetAll();

            //Act
            await this.service.Add(viewModel);

            //Assert
            Assert.IsTrue(repo.All<Transfer>().Any(u => u.CreateDatetime == viewModel.CreateDatetime && u.FromStoreId == viewModel.FromStoreId && u.ToStoreId == viewModel.ToStoreId));
        }

        //[Test]
        //public async Task TransferService_Get_GetById()
        //{
        //    //Arrange
        //    Guid storeFromId = Guid.NewGuid();
        //    Store sotreFrom = new Store()
        //    {
        //        Id = storeFromId,
        //        Name= "Test1",
        //        Description="descr1",
        //        IsActive= true,
        //    };
        //    await repo.AddAsync<Store>(sotreFrom);

        //    Guid storeToId = Guid.NewGuid();
        //    Store sotreTo = new Store()
        //    {
        //        Id = storeToId,
        //        Name = "Test2",
        //        Description = "descr2",
        //        IsActive = true,
        //    };
        //    await repo.AddAsync<Store>(sotreTo);
        //    await repo.SaveChangesAsync();

        //    Guid delivDetId = Guid.NewGuid();
        //    PartidesInStore fromPartInStore = new PartidesInStore()
        //    {
        //        DeliveryDetailId = delivDetId,
        //        Qty = 50.8,
        //        StoreId = Guid.NewGuid(),
        //    };
        //    await repo.AddAsync<PartidesInStore>(fromPartInStore);

        //    PartidesInStore toPartInStore = new PartidesInStore()
        //    {
        //        DeliveryDetailId = delivDetId,
        //        Qty = 20.2,
        //        StoreId = Guid.NewGuid(),
        //    };
        //    await repo.AddAsync<PartidesInStore>(toPartInStore);

        //    await repo.SaveChangesAsync();

        //    TransferViewModel viewModel = new TransferViewModel()
        //    {
        //        CreateDatetime = DateTime.Now,
        //        FromStoreId = fromPartInStore.StoreId,
        //        ToStoreId = toPartInStore.StoreId,
        //        IsActive = true,
        //    };
        //    viewModel.Details.Add(new TransferDetailViewModel()
        //    {
        //        DeliveryDetailId = delivDetId,
        //        IsActive = true,
        //        Qty = 10.3,
        //        Transfer = viewModel
        //    });
        //    IEnumerable<TransferViewModel> allUnits = await service.GetAll();
        //    await this.service.Add(viewModel);
        //    List<Transfer> items =  repo.AllReadonly<Transfer>().ToList();
        //    Guid id = items[0].Id;

        //   //Act
        //   TransferViewModel result = await service.Get(id);

        //    //Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
