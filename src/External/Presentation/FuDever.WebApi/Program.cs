using System;
using System.Text;
using System.Threading;
using FuDever.AppJwt;
using FuDever.Application;
using FuDever.Application.Shared.FIleObjectStorage;
using FuDever.Domain.Entities;
using FuDever.GoogleSmtp;
using FuDever.ImageCloudinary;
using FuDever.PostgresSql;
using FuDever.PostgresSql.Data;
using FuDever.Redis;
using FuDever.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.JsonWebTokens;

// Custom settings.
AppContext.SetSwitch(switchName: "Npgsql.DisableDateTimeInfinityConversions", isEnabled: true);
Console.OutputEncoding = Encoding.UTF8;
JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

var builder = WebApplication.CreateBuilder(args: args);

var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
services.AddApplication();
services.AddPostgresSqlRelationalDatabase(configuration: configuration);
services.AddWebApi(configuration: configuration);
services.AddCloudinaryImageStorage();
services.AddAppJwtIdentityService();
services.AddGoogleSmtpMailNotification(configuration: configuration);
services.AddRedisCachingDatabase(configuration: configuration);

var app = builder.Build();

// Data seeding.
await using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FuDeverContext>();

    // Can database be connected.
    var canConnect = await context.Database.CanConnectAsync();

    // Database cannot be connected.
    if (!canConnect)
    {
        throw new HostAbortedException(message: "Cannot connect database.");
    }

    // Try seed data.
    var seedResult = await EntityDataSeeding.SeedAsync(
        context: context,
        userManager: scope.ServiceProvider.GetRequiredService<UserManager<User>>(),
        roleManager: scope.ServiceProvider.GetRequiredService<RoleManager<Role>>(),
        defaultUserAvatarAsUrlHandler: scope.ServiceProvider.GetRequiredService<IDefaultUserAvatarAsUrlHandler>(),
        cancellationToken: CancellationToken.None
    );

    // Data cannot be seed.
    if (!seedResult)
    {
        throw new HostAbortedException(message: "Database seeding is false.");
    }
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler()
    .UseHttpsRedirection()
    .UseRouting()
    .UseCors()
    .UseAuthentication()
    .UseRateLimiter()
    .UseSwagger()
    .UseSwaggerUI(setupAction: options =>
    {
        options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "v1");
        options.RoutePrefix = string.Empty;
        options.DefaultModelsExpandDepth(depth: -1);
    });

app.MapControllers();

app.Run();
