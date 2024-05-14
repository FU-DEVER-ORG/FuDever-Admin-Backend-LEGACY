using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Position.UpdatePositionByPositionId.Middlewares;

/// <summary>
///     Update position by position id
///     request validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 2)]
internal sealed class UpdatePositionByPositionIdValidationMiddleware
    : IPipelineBehavior<UpdatePositionByPositionIdRequest, UpdatePositionByPositionIdResponse>,
        IUpdatePositionByPositionIdMiddleware
{
    private readonly IValidator<UpdatePositionByPositionIdRequest> _validator;

    public UpdatePositionByPositionIdValidationMiddleware(
        IValidator<UpdatePositionByPositionIdRequest> validator
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
    public async Task<UpdatePositionByPositionIdResponse> Handle(
        UpdatePositionByPositionIdRequest request,
        RequestHandlerDelegate<UpdatePositionByPositionIdResponse> next,
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
                StatusCode = UpdatePositionByPositionIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            };
        }

        return await next();
    }
}
