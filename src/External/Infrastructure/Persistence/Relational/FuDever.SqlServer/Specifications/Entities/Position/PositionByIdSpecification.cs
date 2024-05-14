using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.Position;

namespace FuDever.SqlServer.Specifications.Entities.Position;

/// <summary>
///     Represent implementation of position by position id specification.
/// </summary>
internal sealed class PositionByIdSpecification
    : BaseSpecification<Domain.Entities.Position>,
        IPositionByIdSpecification
{
    internal PositionByIdSpecification(Guid positionId)
    {
        WhereExpression = position => position.Id == positionId;
    }
}
