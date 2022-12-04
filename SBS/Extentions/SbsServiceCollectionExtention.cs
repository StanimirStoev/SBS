using SBS.Core.Contract;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension for dependenci injection
    /// </summary>
    public static class SbsServiceCollectionExtension
    {
        /// <summary>
        /// Add application dependenci injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
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
