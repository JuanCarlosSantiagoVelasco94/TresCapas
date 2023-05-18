using Microsoft.EntityFrameworkCore;
using CRUD.DAL.DataContext;
using CRUD.Models;
using CRUD.DAL.Repositories;
using CRUD.BLL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VideojuegosCrudContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

builder.Services.AddScoped<IGenericRepository<Juego>, VideojuegosRepository>();
builder.Services.AddScoped<IVideojuegoService, VideojuegoService>();

var app = builder.Build();

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
