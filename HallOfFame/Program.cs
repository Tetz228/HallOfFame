using HallOfFame.Db;
using HallOfFame.Repositories;
using HallOfFame.Repositories.Interfaces;
using HallOfFame.Services;
using HallOfFame.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    //Настройка сервисов.

    builder.Services.AddSwaggerGen(genOptions =>
    {
        genOptions.SwaggerDoc("v1", new OpenApiInfo {Title = "HallOfFame", Version = "v1"});
    });
    builder.Services.AddControllers();
    builder.Services.AddDbContext<HallOfFameContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<IPersonService, PersonService>();
    builder.Services.AddScoped<IPersonRepository, PersonRepository>();
    builder.Services.AddScoped<ISkillRepository, SkillRepository>();
    //Подключение логирования.

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();
    //Настройка приложения.

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }

    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Программа остановлена из-за исключения!");
}
finally
{
    LogManager.Shutdown();
}