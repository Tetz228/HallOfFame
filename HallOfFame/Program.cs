using HallOfFame;
using HallOfFame.Repositorys;
using HallOfFame.Repositorys.Interfaces;
using HallOfFame.Services;
using HallOfFame.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//Настройка сервисов.

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "HallOfFame", Version = "v1"}); });
builder.Services.AddControllers();
builder.Services.AddDbContext<HallOfFameContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();
//Настройка приложения.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "hof-api V1"); });
}

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();