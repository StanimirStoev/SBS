using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Services;
using SBS.Infrastructure.Data;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models.Account;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISbsRepository, SbsRepository>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IContragentService, ContragentService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IArticlesInStockService, ArticlesInStockService>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<IPartidesInStoresService, PartidesInStoresService>();
builder.Services.AddScoped<ISellService, SellService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();//Dont wana use razor pages

app.Run();
