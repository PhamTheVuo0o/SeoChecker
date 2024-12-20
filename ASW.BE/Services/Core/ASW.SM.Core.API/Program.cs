using ASW.SM.Identity.API.Application.Behavior;
using ASW.SM.Infrastructure.Cache.Services;
using ASW.SM.Infrastructure.Common;
using ASW.SM.Infrastructure.Middleware;
using ASW.SM.Infrastructure.Services;
using ASW.SM.Infrastructure.Extensions;
using ASW.SM.Infrastructure.DataSync.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSetting"));

builder.Services.AddLogging(logging =>
{
    logging.AddSerilog(new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("Logs\\app.log")
        .CreateLogger());
});

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCorsPolicyServices(builder.Configuration);

builder.Services.AddCustomAuthentication(builder.Configuration);

builder.Services.AddCustomAuthorization();

builder.Services.AddSingleton(new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
}).CreateMapper());

builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.ConfigureCacheManagerServices(builder.Configuration);

builder.Services.ConfigureDataSyncServices();

var app = builder.Build();

Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")} INF] App Run With " +
    $"{app.Environment.EnvironmentName} environment.");

app.UseCorsPolicyServices();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevEnv())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
