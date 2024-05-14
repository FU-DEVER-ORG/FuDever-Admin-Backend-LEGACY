using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.User.GetAllUsers.Middlewares;

/// <summary>
///     Get all users request validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class GetAllUsersValidationMiddleware
    : IPipelineBehavior<GetAllUsersRequest, GetAllUsersResponse>,
        IGetAllUsersMiddleware
{
    private readonly IValidator<GetAllUsersRequest> _validator;

    public GetAllUsersValidationMiddleware(IValidator<GetAllUsersRequest> validator)
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
    public async Task<GetAllUsersResponse> Handle(
        GetAllUsersRequest request,
        RequestHandlerDelegate<GetAllUsersResponse> next,
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
                StatusCode = GetAllUsersResponseStatusCode.INPUT_VALIDATION_FAIL,
                FoundUsers = default
            };
        }

        return await next();
    }
}
