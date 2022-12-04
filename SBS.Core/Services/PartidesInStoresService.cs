using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;

namespace SBS.Core.Services
{
    /// <summary>
    /// Service for Partides in Stores
    /// </summary>
    public class PartidesInStoresService : IPartidesInStoresService
    {
        private readonly ISbsRepository repo;
        /// <summary>
        /// Init service
        /// </summary>
        /// <param name="repo"></param>
        public PartidesInStoresService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Get list of all Partides in Stores
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PartidesInStoreViewModel>> GetAll()
        {
            return await repo.AllReadonly<PartidesInStore>()
                .Where(p => p.Qty > 0)
                .Include(p => p.DeliveryDetail)
                .Include(p => p.DeliveryDetail.Article)
                .Include(p => p.DeliveryDetail.Article.Unit)
                .Include(p => p.DeliveryDetail.Delivery)
                .Include(p => p.Store)
                .Select(p => new PartidesInStoreViewModel()
                {

                    DeliveryDetailId = p.DeliveryDetailId,
                    DeliveryDetail = new DeliveryDetailViewModel()
                    {
                        Id = p.DeliveryDetail.Id,
                        Qty = p.DeliveryDetail.Qty,
                        ArticleId = p.DeliveryDetail.ArticleId,
                        Article = new ArticleViewModel()
                        {
                            Id = p.DeliveryDetail.ArticleId,
                            DeliveryNumber = p.DeliveryDetail.Article.DeliveryNumber,
                            Description = p.DeliveryDetail.Article.Description,
                            IsActive = p.DeliveryDetail.Article.IsActive,
                            Model = p.DeliveryDetail.Article.Model,
                            Name = p.DeliveryDetail.Article.Name,
                            Title = p.DeliveryDetail.Article.Title,
                            UnitId = p.DeliveryDetail.Article.UnitId,
                            Unit = new UnitViewModel()
                            {
                                Id = p.DeliveryDetail.Article.Unit.Id,
                                Name = p.DeliveryDetail.Article.Unit.Name,
                                Description = p.DeliveryDetail.Article.Unit.Description,
                                IsActive = p.DeliveryDetail.Article.Unit.IsActive
                            }
                        },
                        DeliveryId = p.DeliveryDetail.Delivery.Id,
                        Delivery = new DeliveryViewModel()
                        {
                            Id = p.DeliveryDetail.Delivery.Id,
                            ContragentId = p.DeliveryDetail.Delivery.ContragentId,
                            IsActive = p.DeliveryDetail.Delivery.IsActive,
                            CreateDatetime = p.DeliveryDetail.Delivery.CreateDatetime,
                            IsConfirmed = p.DeliveryDetail.Delivery.IsConfirmed,
                            StoreId = p.DeliveryDetail.Delivery.StoreId,
                        },
                        Price = p.DeliveryDetail.Price,
                        UnitId = p.DeliveryDetail.UnitId,
                        IsActive = p.DeliveryDetail.IsActive,
                    },
                    StoreId = p.StoreId,
                    Store = new StoreViewModel()
                    {
                        Id = p.Store.Id,
                        IsActive = p.Store.IsActive,
                        Description = p.Store.Description,
                        Name = p.Store.Name,
                    },
                    Qty = p.Qty,
                }).ToListAsync();
        }
    }
}
