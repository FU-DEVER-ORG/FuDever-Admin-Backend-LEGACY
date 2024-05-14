﻿using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Hobby.GetAllHobbies;
using FuDever.Application.Features.Hobby.GetAllHobbiesByHobbyName;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Hobby.CreateHobby.Middlewares;

/// <summary>
///     Create hobby request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class CreateHobbyCachingMiddleware
    : IPipelineBehavior<CreateHobbyRequest, CreateHobbyResponse>,
        ICreateHobbyMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public CreateHobbyCachingMiddleware(ICacheHandler cacheHandler)
    {
        _cacheHandler = cacheHandler;
    }

    /// <summary>
    ///     Entry to middleware handler.
    /// </summary>
    /// <param name="request">
    ///     Current request object.
    /// </param>
    /// <param name="next">
    ///     Navigate to next middleware and get back response.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     Response of use case.
    /// </returns>
    public async Task<CreateHobbyResponse> Handle(
        CreateHobbyRequest request,
        RequestHandlerDelegate<CreateHobbyResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (response.StatusCode == CreateHobbyResponseStatusCode.OPERATION_SUCCESS)
        {
            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllHobbiesByHobbyNameRequest)}_param_{request.NewHobbyName.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllHobbiesRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
