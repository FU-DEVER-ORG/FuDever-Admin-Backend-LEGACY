using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.RateLimiting;
using FuDever.Configuration.Presentation.WebApi.ApiController;
using FuDever.Configuration.Presentation.WebApi.Authentication;
using FuDever.Configuration.Presentation.WebApi.RateLimiter;
using FuDever.Configuration.Presentation.WebApi.Swagger;
using FuDever.WebApi.ActionResults;
using FuDever.WebApi.AppCodes;
using FuDever.WebApi.Commons;
using FuDever.WebApi.HttpResponseMapper.Others;
using FuDever.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FuDever.WebApi;

/// <summary>
///     Configure services for this layer.
/// </summary>
internal static class DependencyInjection
{
    /// <summary>
    ///     Entry to configuring multiple services.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    /// <param name="configuration">
    ///     Load configuration for configuration
    ///     file (appsetting).
    /// </param>
    internal static void AddWebApi(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.ConfigureAuthentication(configuration: configuration);

        services.ConfigureLogging();

        services.ConfigureCORS();

        services.ConfigureController(configuration: configuration);

        services.ConfigureSwagger(configuration: configuration);

        services.ConfigureRateLimiter(configuration: configuration);

        services.ConfigureExceptionHandler();

        services.ConfigureCore(configuration: configuration);
    }

    /// <summary>
    ///     Configure the authentication service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    /// <param name="configuration">
    ///     Load configuration for configuration
    ///     file (appsetting).
    /// </param>
    private static void ConfigureAuthentication(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        var option = configuration
            .GetRequiredSection(key: "Authentication")
            .Get<JwtAuthenticationOption>();

        services
            .AddAuthentication(configureOptions: config =>
            {
                config.DefaultAuthenticateScheme = option.Common.DefaultAuthenticateScheme;
                config.DefaultScheme = option.Common.DefaultScheme;
                config.DefaultChallengeScheme = option.Common.DefaultChallengeScheme;
            })
            .AddJwtBearer(configureOptions: config =>
                config.TokenValidationParameters = GetTokenValidationParameters(
                    configuration: configuration
                )
            );
    }

    /// <summary>
    ///     Configure the logging service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    private static void ConfigureLogging(this IServiceCollection services)
    {
        services.AddLogging(configure: config =>
        {
            config.ClearProviders();
            config.AddConsole();
        });
    }

    /// <summary>
    ///     Configure the CORS service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    private static void ConfigureCORS(this IServiceCollection services)
    {
        services.AddCors(setupAction: config =>
        {
            config.AddDefaultPolicy(configurePolicy: policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });
    }

    /// <summary>
    ///     Configure the controller service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    /// <param name="configuration">
    ///     Load configuration for configuration
    ///     file (appsetting).
    /// </param>
    private static void ConfigureController(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        var option = configuration
            .GetRequiredSection(key: "ApiController")
            .Get<ApiControllerOption>();

        services
            .AddControllers(configure: config =>
                config.SuppressAsyncSuffixInActionNames = option.SuppressAsyncSuffixInActionNames
            )
            .AddJsonOptions(configure: config => config.JsonSerializerOptions.WriteIndented = true)
            .ConfigureApiBehaviorOptions(setupAction: config =>
                config.InvalidModelStateResponseFactory = _ => new CustomBadRequestResult()
            );
    }

    /// <summary>
    ///     Configure the swagger service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    /// <param name="configuration">
    ///     Load configuration for configuration
    ///     file (appsetting).
    /// </param>
    private static void ConfigureSwagger(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.AddSwaggerGen(setupAction: config =>
        {
            var option = configuration
                .GetRequiredSection(key: "Swagger")
                .GetRequiredSection(key: "Swashbuckle")
                .Get<SwashbuckleOption>();

            config.SwaggerDoc(
                name: option.Doc.Name,
                info: new()
                {
                    Version = option.Doc.Info.Version,
                    Title = option.Doc.Info.Title,
                    Description = option.Doc.Info.Description,
                    Contact = new()
                    {
                        Name = option.Doc.Info.Contact.Name,
                        Email = option.Doc.Info.Contact.Email
                    },
                    License = new()
                    {
                        Name = option.Doc.Info.License.Name,
                        Url = new(uriString: option.Doc.Info.License.Url)
                    }
                }
            );

            config.AddSecurityDefinition(
                name: option.Security.Definition.Name,
                securityScheme: new()
                {
                    Description = option.Security.Definition.SecurityScheme.Description,
                    Name = option.Security.Definition.SecurityScheme.Name,
                    In = (ParameterLocation)
                        Enum.ToObject(
                            enumType: typeof(ParameterLocation),
                            value: option.Security.Definition.SecurityScheme.In
                        ),
                    Type = (SecuritySchemeType)
                        Enum.ToObject(
                            enumType: typeof(SecuritySchemeType),
                            value: option.Security.Definition.SecurityScheme.Type
                        ),
                    Scheme = option.Security.Definition.SecurityScheme.Scheme
                }
            );

            config.AddSecurityRequirement(
                securityRequirement: new()
                {
                    {
                        new()
                        {
                            Reference = new()
                            {
                                Type = (ReferenceType)
                                    Enum.ToObject(
                                        enumType: typeof(ReferenceType),
                                        value: option
                                            .Security
                                            .Requirement
                                            .OpenApiSecurityScheme
                                            .Reference
                                            .Type
                                    ),
                                Id = option.Security.Requirement.OpenApiSecurityScheme.Reference.Id
                            },
                            Scheme = option.Security.Requirement.OpenApiSecurityScheme.Scheme,
                            Name = option.Security.Requirement.OpenApiSecurityScheme.Name,
                            In = (ParameterLocation)
                                Enum.ToObject(
                                    enumType: typeof(ParameterLocation),
                                    value: option.Security.Requirement.OpenApiSecurityScheme.In
                                ),
                        },
                        option.Security.Requirement.Values
                    }
                }
            );

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            var xmlFilePath = Path.Combine(path1: AppContext.BaseDirectory, path2: xmlFilename);

            config.IncludeXmlComments(filePath: xmlFilePath);
        });
    }

    /// <summary>
    ///     Configure the rate limiter service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    /// <param name="configuration">
    ///     Load configuration for configuration
    ///     file (appsetting).
    /// </param>
    private static void ConfigureRateLimiter(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.AddRateLimiter(configureOptions: config =>
        {
            config.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(
                partitioner: context =>
                {
                    var option = configuration
                        .GetRequiredSection(key: "ApiRateLimiter")
                        .GetRequiredSection(key: "FixedWindow")
                        .Get<FixedWindowRateLimiterOption>();

                    return RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: context.Connection.RemoteIpAddress.ToString(),
                        factory: _ =>
                            new()
                            {
                                PermitLimit = option.RemoteIpAddress.PermitLimit,
                                QueueProcessingOrder = (QueueProcessingOrder)
                                    Enum.ToObject(
                                        enumType: typeof(QueueProcessingOrder),
                                        value: option.RemoteIpAddress.QueueProcessingOrder
                                    ),
                                QueueLimit = option.RemoteIpAddress.QueueLimit,
                                Window = TimeSpan.FromSeconds(value: option.RemoteIpAddress.Window),
                                AutoReplenishment = option.RemoteIpAddress.AutoReplenishment,
                            }
                    );
                }
            );

            config.OnRejected = async (option, cancellationToken) =>
            {
                option.HttpContext.Response.Clear();
                option.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

                await option.HttpContext.Response.WriteAsJsonAsync(
                    value: new CommonResponse
                    {
                        AppCode = (int)OtherAppCode.SERVER_ERROR,
                        ErrorMessages = ["Two many request.", "Please try again later."]
                    },
                    cancellationToken: cancellationToken
                );

                await option.HttpContext.Response.CompleteAsync();
            };
        });
    }

    /// <summary>
    ///     Configure the exception handler service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    private static void ConfigureExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>().AddProblemDetails();
    }

    /// <summary>
    ///     Configure core services.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    /// <param name="configuration">
    ///     Load configuration for configuration
    ///     file (appsetting).
    /// </param>
    private static void ConfigureCore(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services
            .AddSingleton(
                implementationInstance: GetTokenValidationParameters(configuration: configuration)
            )
            .AddSingleton<JsonWebTokenHandler>()
            .AddSingleton<HttpResponseMapperManager>();
    }

    /// <summary>
    ///     Return pre=defined token validation parameter.
    /// </summary>
    /// <param name="configuration">
    ///     Load configuration for configuration
    ///     file (appsetting).
    /// </param>
    /// <returns>
    ///     Token validation parameter.
    /// </returns>
    private static TokenValidationParameters GetTokenValidationParameters(
        IConfigurationManager configuration
    )
    {
        var option = configuration
            .GetRequiredSection(key: "Authentication")
            .GetRequiredSection(key: "Type")
            .Get<JwtAuthenticationOption>();

        return new()
        {
            ValidateIssuer = option.Jwt.ValidateIssuer,
            ValidateAudience = option.Jwt.ValidateAudience,
            ValidateLifetime = option.Jwt.ValidateLifetime,
            ValidateIssuerSigningKey = option.Jwt.ValidateIssuerSigningKey,
            RequireExpirationTime = option.Jwt.RequireExpirationTime,
            ValidTypes = option.Jwt.ValidTypes,
            ValidIssuer = option.Jwt.ValidIssuer,
            ValidAudience = option.Jwt.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(
                key: new HMACSHA256(key: Encoding.UTF8.GetBytes(s: option.Jwt.IssuerSigningKey)).Key
            )
        };
    }
}
