using ASP.NET_CORE_TRY.DataBase;
using ASP.NET_CORE_TRY.Repository;
using ASP.NET_CORE_TRY.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//builder.Services.AddTransient<IRepository<User>, UserRepository>();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(connection));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();