﻿using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Platform.CreatePlatform.Middlewares;

/// <summary>
///     Create platform request validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 2)]
internal sealed class CreatePlatformValidationMiddleware
    : IPipelineBehavior<CreatePlatformRequest, CreatePlatformResponse>,
        ICreatePlatformMiddleware
{
    private readonly IValidator<CreatePlatformRequest> _validator;

    public CreatePlatformValidationMiddleware(IValidator<CreatePlatformRequest> validator)
    {
        _validator = validator;
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
    public async Task<CreatePlatformResponse> Handle(
        CreatePlatformRequest request,
        RequestHandlerDelegate<CreatePlatformResponse> next,
        CancellationToken cancellationToken
    )
    {
        // Validate input.
        var inputValidationResult = await _validator.ValidateAsync(
            instance: request,
            cancellation: cancellationToken
        );

        // Input is not valid.
        if (!inputValidationResult.IsValid)
        {
            return new() { StatusCode = CreatePlatformResponseStatusCode.INPUT_VALIDATION_FAIL };
        }

        return await next();
    }
}
