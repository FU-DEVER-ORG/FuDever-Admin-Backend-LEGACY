using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Hobby.GetAllHobbiesByHobbyName.Middlewares;

/// <summary>
///     Get all hobbies by hobby name
///     request validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class GetAllHobbiesByHobbyNameValidationMiddleware
    : IPipelineBehavior<GetAllHobbiesByHobbyNameRequest, GetAllHobbiesByHobbyNameResponse>,
        IGetAllHobbiesByHobbyNameMiddleware
{
    private readonly IValidator<GetAllHobbiesByHobbyNameRequest> _validator;

    public GetAllHobbiesByHobbyNameValidationMiddleware(
        IValidator<GetAllHobbiesByHobbyNameRequest> validator
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

    public async Task<GetAllHobbiesByHobbyNameResponse> Handle(
        GetAllHobbiesByHobbyNameRequest request,
        RequestHandlerDelegate<GetAllHobbiesByHobbyNameResponse> next,
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
                StatusCode = GetAllHobbiesByHobbyNameResponseStatusCode.INPUT_VALIDATION_FAIL,
                FoundHobbies = default
            };
        }

        return await next();
    }
}
