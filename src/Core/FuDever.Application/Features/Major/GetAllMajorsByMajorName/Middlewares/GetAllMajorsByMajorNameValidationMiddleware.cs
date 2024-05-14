﻿using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Major.GetAllMajorsByMajorName.Middlewares;

/// <summary>
///     Get all majors by major name
///     request validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class GetAllMajorsByMajorNameValidationMiddleware
    : IPipelineBehavior<GetAllMajorsByMajorNameRequest, GetAllMajorsByMajorNameResponse>,
        IGetAllMajorsByMajorNameMiddleware
{
    private readonly IValidator<GetAllMajorsByMajorNameRequest> _validator;

    public GetAllMajorsByMajorNameValidationMiddleware(
        IValidator<GetAllMajorsByMajorNameRequest> validator
    )
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
    public async Task<GetAllMajorsByMajorNameResponse> Handle(
        GetAllMajorsByMajorNameRequest request,
        RequestHandlerDelegate<GetAllMajorsByMajorNameResponse> next,
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
            return new()
            {
                StatusCode = GetAllMajorsByMajorNameResponseStatusCode.INPUT_VALIDATION_FAIL,
                FoundMajors = default
            };
        }

        return await next();
    }
}
