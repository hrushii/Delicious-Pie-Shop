using DeliciousPieShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DeliciousPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'DeliciousPieShopDbContextConnection' not found.");

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

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DeliciousPieShopDbContext>();
//builder.Services.AddControllers(); -> no need as AddCOntrollersWithView is used
builder.Services.AddServerSideBlazor();
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();

app.UseDeveloperExceptionPage();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapBlazorHub();//for SignalR
app.MapFallbackToPage("/app/{*catchcall}", "/App/Index");

DbInitializer.Seed(app);
app.Run();
