using Flurl.Http.Configuration;
using Ishraq.SavijSell.Ui.Repositories;
using Ishraq.SavijSell.Ui.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserManagementRepository, UserManagementRepository>();
builder.Services.AddSingleton<IUserManagementService, UserManagementService>();
builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
builder.Services.AddSingleton<IProductsService, ProductsService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserManagement}/{action=Index}/{id?}");

app.Run();
