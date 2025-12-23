var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(typeof(IRepository<>), typeof(InMemoryRepo<>));

builder.Services.Configure<RouteOptions>(opts 
   => opts.LowercaseUrls = true);

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();