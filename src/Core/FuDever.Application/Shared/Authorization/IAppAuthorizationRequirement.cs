using MediatR;

namespace FuDever.Application.Shared.Authorization;

/// <summary>
///     Interface that represents requirement for authorization.
/// </summary>
public interface IAppAuthorizationRequirement : IRequest<AppAuthorizationResult> { }
