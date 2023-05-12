using DeliciousPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddDbContext<DeliciousPieShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DeliciousPieShopDbContextConnection"]);
});

var app = builder.Build();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();
app.MapDefaultControllerRoute();
app.Run();
