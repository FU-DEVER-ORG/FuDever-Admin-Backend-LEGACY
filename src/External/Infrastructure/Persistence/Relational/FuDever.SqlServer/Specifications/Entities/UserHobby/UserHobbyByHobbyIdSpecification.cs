using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.UserHobby;

namespace FuDever.SqlServer.Specifications.Entities.UserHobby;

/// <summary>
///     Represent implementation of user hobby by hobby
///     id specification.
/// </summary>
internal sealed class UserHobbyByHobbyIdSpecification
    : BaseSpecification<Domain.Entities.UserHobby>,
        IUserHobbyByHobbyIdSpecification
{
    public UserHobbyByHobbyIdSpecification(Guid hobbyId)
    {
        WhereExpression = userHobby => userHobby.HobbyId == hobbyId;
    }
}
