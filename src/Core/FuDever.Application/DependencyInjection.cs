using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FuDever.Application;

/// <summary>
///     Configure services for this layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///     Entry to configuring multiple services.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    public static void AddApplication(this IServiceCollection services)
    {
        services.ConfigureFluentValidation();

        services.ConfigureMediatR();

        services.ConfigureCore();
    }

    /// <summary>
    ///     Configure mediatR service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    private static void ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(configuration: config =>
            config.RegisterServicesFromAssemblyContaining(type: typeof(DependencyInjection))
        );
    }

    /// <summary>
    ///     Configure fluent validation service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    private static void ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(type: typeof(DependencyInjection));
    }

    /// <summary>
    ///     Configure core services.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    private static void ConfigureCore(this IServiceCollection services)
    {
        services.RegisterMiddlewareOfFeature();
    }

    /// <summary>
    ///     Register middleware of feature.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    private static void RegisterMiddlewareOfFeature(this IServiceCollection services)
    {
        const string baseNamespaceOfFeature =
            $"{nameof(FuDever)}.{nameof(Application)}.{nameof(Features)}";

        var featureMiddlewareInfos = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(predicate: type =>
            {
                return type.IsClass && type.FullName.EndsWith(value: "Middleware");
            })
            .Select(selector: type =>
            {
                var tokens = type.FullName.Split(separator: ".");

                return new
                {
                    EntityName = tokens[3],
                    EntityFeatureName = tokens[4],
                    EntityFeatureMiddlewareName = tokens[6]
                };
            })
            .ToLookup(keySelector: entity => entity.EntityFeatureName);

        List<Type> featureMiddlewareTypes = [];

        var pipelineBehaviorType = typeof(IPipelineBehavior<,>);

        foreach (var featureMiddlewareInfo in featureMiddlewareInfos)
        {
            var values = featureMiddlewareInfo.First();

            var entityFeatureNamespace =
                $"{baseNamespaceOfFeature}.{values.EntityName}.{values.EntityFeatureName}";

            var entityFeatureRequestType = Type.GetType(
                typeName: $"{entityFeatureNamespace}.{values.EntityFeatureName}Request"
            );

            var entityFeatureResponseType = Type.GetType(
                typeName: $"{entityFeatureNamespace}.{values.EntityFeatureName}Response"
            );

            foreach (var properties in featureMiddlewareInfo)
            {
                var featureMiddlewareType = Type.GetType(
                    typeName: $"{entityFeatureNamespace}.Middlewares.{properties.EntityFeatureMiddlewareName}"
                );

                featureMiddlewareTypes.Add(item: featureMiddlewareType);
            }

            featureMiddlewareTypes.Sort(
                comparison: (first, second) =>
                {
                    var firstAttr =
                        first?.GetCustomAttribute<FeatureMiddlewareOrderAttribute>()?.Value
                        ?? default;

                    var secondAttr =
                        second?.GetCustomAttribute<FeatureMiddlewareOrderAttribute>()?.Value
                        ?? default;

                    return firstAttr.CompareTo(value: secondAttr);
                }
            );

            foreach (var featureMiddlewareType in featureMiddlewareTypes)
            {
                services.AddScoped(
                    serviceType: pipelineBehaviorType.MakeGenericType(
                        entityFeatureRequestType,
                        entityFeatureResponseType
                    ),
                    implementationType: featureMiddlewareType
                );
            }

            featureMiddlewareTypes.Clear();
        }
    }
}
