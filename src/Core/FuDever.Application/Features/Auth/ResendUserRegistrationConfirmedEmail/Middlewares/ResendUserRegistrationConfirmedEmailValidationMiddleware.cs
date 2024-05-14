using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail.Middlewares;

/// <summary>
///     Resend user registration confirmed email validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class ResendUserRegistrationConfirmedEmailValidationMiddleware
    : IPipelineBehavior<
        ResendUserRegistrationConfirmedEmailRequest,
        ResendUserRegistrationConfirmedEmailResponse
    >,
        IResendUserRegistrationConfirmedEmailMiddleware
{
    private readonly IValidator<ResendUserRegistrationConfirmedEmailRequest> _validator;

    public ResendUserRegistrationConfirmedEmailValidationMiddleware(
        IValidator<ResendUserRegistrationConfirmedEmailRequest> validator
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
    public async Task<ResendUserRegistrationConfirmedEmailResponse> Handle(
        ResendUserRegistrationConfirmedEmailRequest request,
        RequestHandlerDelegate<ResendUserRegistrationConfirmedEmailResponse> next,
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
                StatusCode =
                    ResendUserRegistrationConfirmedEmailResponseStatusCode.INPUT_VALIDATION_FAIL
            };
        }

        return await next();
    }
}
