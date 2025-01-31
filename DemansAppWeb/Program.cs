using DemansAppWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
IServiceCollection serviceCollection = builder.Services.AddDbContext<EntitiesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name:"default",
     pattern: "{controller=Login}/{action=Index}/{id?}"
    );
});


app.Run();
