using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportsStoreDb"));
});
builder.Services.AddTransient<IProductRepository, EFProductRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.MapControllerRoute(
    name: null,
    pattern: "{category}/Page{productPage:int}",
    defaults: new { Controller = "Product", action = "List" });
app.MapControllerRoute(
    name: null,
    pattern: "Page{productPage:int}",
    defaults: new { Controller = "Product", action = "List", productPage = 1 });
app.MapControllerRoute(
    name: null,
    pattern: "{category}",
    defaults: new { Controller = "Product", action = "List", productPage = 1 });
app.MapControllerRoute(
    name: null,
    pattern: "",
    defaults: new { Controller = "Product", action = "List", productPage = 1 });
app.MapControllerRoute(
    name: null,
    pattern: "{controller}/{action}/{id?}");

app.Run();
