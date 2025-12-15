var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.Configure<RouteOptions>(opts => opts.LowercaseUrls = true);

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.MapStaticAssets();

//app.MapControllers()
app.MapDefaultControllerRoute().WithStaticAssets();

app.Run();