using DeliciousPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart,ShoppingCart>(sp=>ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<DeliciousPieShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DeliciousPieShopDbContextConnection"]);
});

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();

app.UseDeveloperExceptionPage();
app.MapDefaultControllerRoute();
DbInitializer.Seed(app);
app.Run();
