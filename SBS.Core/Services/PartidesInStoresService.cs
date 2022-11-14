using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Services
{
    public class PartidesInStoresService : IPartidesInStoresService
    {
        private readonly ISbsRepository repo;

        public PartidesInStoresService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<PartidesInStoreViewModel>> GetAll()
        {
            return await repo.AllReadonly<PartidesInStore>()
                .Where(p => p.Qty > 0)
                .Include(p => p.DeliveryDetail)
                .Include(p => p.DeliveryDetail.Article)
                .Include(p => p.DeliveryDetail.Delivery)
                .Include(d => d.Store)
                .Select(d => new PartidesInStoreViewModel()
                {

                    DeliveryDetailId = d.DeliveryDetailId,
                    DeliveryDetail = new DeliveryDetailViewModel()
                    {
                        Id = d.DeliveryDetail.Id,
                        Qty = d.DeliveryDetail.Qty,
                        ArticleId = d.DeliveryDetail.ArticleId,
                        Article = new ArticleViewModel()
                        {
                            Id = d.DeliveryDetail.ArticleId,
                            DeliveryNumber = d.DeliveryDetail.Article.DeliveryNumber,
                            Description = d.DeliveryDetail.Article.Description,
                            IsActive = d.DeliveryDetail.Article.IsActive,
                            Model = d.DeliveryDetail.Article.Model,
                            Name = d.DeliveryDetail.Article.Name,
                            Title = d.DeliveryDetail.Article.Title,
                            UnitId = d.DeliveryDetail.Article.UnitId
                        },
                        DeliveryId = d.DeliveryDetail.Delivery.Id,
                        Delivery = new DeliveryViewModel()
                        {
                            Id = d.DeliveryDetail.Delivery.Id,
                            ContragentId = d.DeliveryDetail.Delivery.ContragentId,
                            IsActive = d.DeliveryDetail.Delivery.IsActive,
                            CreateDatetime = d.DeliveryDetail.Delivery.CreateDatetime,
                            IsConfirmed = d.DeliveryDetail.Delivery.IsConfirmed,
                            StoreId = d.DeliveryDetail.Delivery.StoreId,
                        },
                        Price = d.DeliveryDetail.Price,
                        UnitId = d.DeliveryDetail.UnitId,
                        IsActive = d.DeliveryDetail.IsActive,
                    },
                    StoreId = d.StoreId,
                    Store = new StoreViewModel()
                    {
                        Id = d.Store.Id,
                        IsActive = d.Store.IsActive,
                        Description = d.Store.Description,
                        Name = d.Store.Name,
                    },
                    Qty = d.Qty,
                }).ToListAsync();
        }
    }
}
