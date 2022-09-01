using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _272Ass3.Data;
using _272Ass3.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<_272Ass3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("_272Ass3Context") ?? throw new InvalidOperationException("Connection string '_272Ass3Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
