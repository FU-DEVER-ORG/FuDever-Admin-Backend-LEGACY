using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FuDever.Application.Shared.Attributes;
using MediatR;

namespace FuDever.Application.Features.Major.GetAllMajors.Middlewares;

/// <summary>
///     Get all majors request validation middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class GetAllMajorsValidationMiddleware
    : IPipelineBehavior<GetAllMajorsRequest, GetAllMajorsResponse>,
        IGetAllMajorsMiddleware
{
    private readonly IValidator<GetAllMajorsRequest> _validator;

    public GetAllMajorsValidationMiddleware(IValidator<GetAllMajorsRequest> validator)
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
    public async Task<GetAllMajorsResponse> Handle(
        GetAllMajorsRequest request,
        RequestHandlerDelegate<GetAllMajorsResponse> next,
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
                StatusCode = GetAllMajorsResponseStatusCode.INPUT_VALIDATION_FAIL,
                FoundMajors = default
            };
        }

        return await next();
    }
}
