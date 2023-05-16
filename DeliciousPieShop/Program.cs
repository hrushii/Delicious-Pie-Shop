using DeliciousPieShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart,ShoppingCart>(sp=>ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DeliciousPieShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DeliciousPieShopDbContextConnection"]);
});
//builder.Services.AddControllers(); -> no need as AddCOntrollersWithView is used
builder.Services.AddServerSideBlazor();
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();

app.UseDeveloperExceptionPage();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapBlazorHub();//for SignalR
app.MapFallbackToPage("/app/{*catchcall}", "App/Index");

DbInitializer.Seed(app);
app.Run();
