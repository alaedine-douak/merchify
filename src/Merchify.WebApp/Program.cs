using Merchify.WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICategoryRepository, CategoriesRepository>();

builder.Services.Configure<RouteOptions>(opts => opts.LowercaseUrls = true);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();