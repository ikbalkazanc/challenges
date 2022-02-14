using Microsoft.EntityFrameworkCore;
using Pazarama.Homework.Core.Constant;
using Pazarama.Homework.Core.Contracts;
using Pazarama.Homework.Core.Contracts.Service;
using Pazarama.Homework.Core.Extension;
using Pazarama.Homework.Data;
using Pazarama.Homework.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(ConnectionStrings.PostgreSql));
builder.Services.AddScoped(typeof(DataRepository));
builder.Services.AddScoped<IBookSevice, BookService>();
var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
SeedData.Seed(app);

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseExceptionLogHandler();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
