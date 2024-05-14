using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId.Middlewares;

/// <summary>
///     Remove hobby permanently by
///     hobby id validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 2)]
internal sealed class RemoveHobbyPermanentlyByHobbyIdValidationMiddleware
    : IPipelineBehavior<
        RemoveHobbyPermanentlyByHobbyIdRequest,
        RemoveHobbyPermanentlyByHobbyIdResponse
    >,
        IRemoveHobbyPermanentlyByHobbyIdMiddleware
{
    private readonly IValidator<RemoveHobbyPermanentlyByHobbyIdRequest> _validator;

    public RemoveHobbyPermanentlyByHobbyIdValidationMiddleware(
        IValidator<RemoveHobbyPermanentlyByHobbyIdRequest> validator
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
    public async Task<RemoveHobbyPermanentlyByHobbyIdResponse> Handle(
        RemoveHobbyPermanentlyByHobbyIdRequest request,
        RequestHandlerDelegate<RemoveHobbyPermanentlyByHobbyIdResponse> next,
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
                StatusCode = RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.INPUT_VALIDATION_FAIL
            };
        }

        return await next();
    }
}
