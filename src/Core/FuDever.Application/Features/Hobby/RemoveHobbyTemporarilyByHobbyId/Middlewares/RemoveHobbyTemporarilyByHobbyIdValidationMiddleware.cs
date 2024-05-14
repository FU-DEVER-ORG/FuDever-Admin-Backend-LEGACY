using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Hobby.RemoveHobbyTemporarilyByHobbyId.Middlewares;

/// <summary>
///     Remove hobby temporarily by
///     hobby id validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 2)]
internal sealed class RemoveHobbyTemporarilyByHobbyIdValidationMiddleware
    : IPipelineBehavior<
        RemoveHobbyTemporarilyByHobbyIdRequest,
        RemoveHobbyTemporarilyByHobbyIdResponse
    >,
        IRemoveHobbyTemporarilyByHobbyIdMiddleware
{
    private readonly IValidator<RemoveHobbyTemporarilyByHobbyIdRequest> _validator;

    public RemoveHobbyTemporarilyByHobbyIdValidationMiddleware(
        IValidator<RemoveHobbyTemporarilyByHobbyIdRequest> validator
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

    public async Task<RemoveHobbyTemporarilyByHobbyIdResponse> Handle(
        RemoveHobbyTemporarilyByHobbyIdRequest request,
        RequestHandlerDelegate<RemoveHobbyTemporarilyByHobbyIdResponse> next,
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
                StatusCode = RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.INPUT_VALIDATION_FAIL
            };
        }

        return await next();
    }
}
