using MediatR;

namespace FuDever.Application.Shared.Authorization;

/// <summary>
///     Implementation of authorization requirement handler.
/// </summary>
/// <typeparam name="TRequirement">
///     Authorization requirement type.
/// </typeparam>
internal interface IAppAuthorizationRequirementHandler<TRequirement>
    : IRequestHandler<TRequirement, AppAuthorizationResult>
    where TRequirement : IAppAuthorizationRequirement { }
