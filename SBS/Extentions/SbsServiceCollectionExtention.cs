using SBS.Core.Contract;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SbsServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISbsRepository, SbsRepository>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IContragentService, ContragentService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IArticlesInStockService, ArticlesInStockService>();
            services.AddScoped<ITransferService, TransferService>();
            services.AddScoped<IPartidesInStoresService, PartidesInStoresService>();
            services.AddScoped<ISellService, SellService>();

            return services;
        }
    }
}
