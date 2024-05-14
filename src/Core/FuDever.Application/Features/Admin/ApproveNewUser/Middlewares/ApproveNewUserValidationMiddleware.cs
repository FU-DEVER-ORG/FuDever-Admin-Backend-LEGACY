using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Admin.ApproveNewUser.Middlewares;

/// <summary>
///     Approve new user request validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 2)]
internal sealed class ApproveNewUserValidationMiddleware
    : IPipelineBehavior<ApproveNewUserRequest, ApproveNewUserResponse>,
        IApproveNewUserMiddleware
{
    private readonly IValidator<ApproveNewUserRequest> _validator;

    public ApproveNewUserValidationMiddleware(IValidator<ApproveNewUserRequest> validator)
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
    public async Task<ApproveNewUserResponse> Handle(
        ApproveNewUserRequest request,
        RequestHandlerDelegate<ApproveNewUserResponse> next,
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
            return new() { StatusCode = ApproveNewUserResponseStatusCode.INPUT_VALIDATION_FAIL };
        }

        return await next();
    }
}
