using Microsoft.EntityFrameworkCore;
using RabbitMQ;
using RabbitMQ.Models;
using RabbitMQ.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var cons = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(cons));
builder.Services.AddTransient<IRepository<Request>, Repository<Request>>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Request}/{action=Index}/{id?}");

app.Run();
