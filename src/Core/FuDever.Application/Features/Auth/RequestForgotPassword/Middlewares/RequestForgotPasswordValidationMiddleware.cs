using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Auth.RequestForgotPassword.Middlewares;

/// <summary>
///     Request Forgot password request validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class RequestForgotPasswordValidationMiddleware
    : IPipelineBehavior<RequestForgotPasswordRequest, RequestForgotPasswordResponse>,
        IRequestForgotPasswordMiddleware
{
    private readonly IValidator<RequestForgotPasswordRequest> _validator;

    public RequestForgotPasswordValidationMiddleware(
        IValidator<RequestForgotPasswordRequest> validator
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
    public async Task<RequestForgotPasswordResponse> Handle(
        RequestForgotPasswordRequest request,
        RequestHandlerDelegate<RequestForgotPasswordResponse> next,
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
                StatusCode = RequestForgotPasswordResponseStatusCode.INPUT_VALIDATION_FAIL
            };
        }

        return await next();
    }
}
