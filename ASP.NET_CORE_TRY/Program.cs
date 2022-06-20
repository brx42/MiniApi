using System.Reflection;
using ASP.NET_CORE_TRY.DataBase;
using ASP.NET_CORE_TRY.Repository;
using ASP.NET_CORE_TRY.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Frontend API", Version = "v1" });
    c.DescribeAllParametersInCamelCase();
    c.CustomSchemaIds(type => type.ToString());
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(connection));

builder.Services.AddScoped(typeof(IRepository<User>), typeof(UserRepository));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => { });

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();