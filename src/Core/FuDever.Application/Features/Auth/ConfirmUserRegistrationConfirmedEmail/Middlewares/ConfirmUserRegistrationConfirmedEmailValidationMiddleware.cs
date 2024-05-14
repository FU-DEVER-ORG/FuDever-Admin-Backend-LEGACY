using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail.Middlewares;

/// <summary>
///     Confirm user registration confirmed email validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class ConfirmUserRegistrationConfirmedEmailValidationMiddleware
    : IPipelineBehavior<
        ConfirmUserRegistrationConfirmedEmailRequest,
        ConfirmUserRegistrationConfirmedEmailResponse
    >,
        IConfirmUserRegistrationConfirmedEmailMiddleware
{
    private readonly IValidator<ConfirmUserRegistrationConfirmedEmailRequest> _validator;

    public ConfirmUserRegistrationConfirmedEmailValidationMiddleware(
        IValidator<ConfirmUserRegistrationConfirmedEmailRequest> validator
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
    public async Task<ConfirmUserRegistrationConfirmedEmailResponse> Handle(
        ConfirmUserRegistrationConfirmedEmailRequest request,
        RequestHandlerDelegate<ConfirmUserRegistrationConfirmedEmailResponse> next,
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
                    ConfirmUserRegistrationConfirmedEmailResponseStatusCode.INPUT_VALIDATION_FAIL
            };
        }

        return await next();
    }
}
