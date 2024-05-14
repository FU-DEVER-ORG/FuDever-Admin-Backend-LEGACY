using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Entities.Base;
using FuDever.Domain.Repositories.Base;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Others;
using FuDever.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.SqlServer.Repositories.Base;

/// <summary>
///     Implementation of base repository.
/// </summary>
/// <typeparam name="TEntity">
///     Represent the table of the database or
///     in the simple term, entity of the system.
/// </typeparam>
/// <remarks>
///     All repository classes must inherit from this
///     base class.
/// </remarks>
internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class, IBaseEntity
{
    protected readonly DbSet<TEntity> _dbSet;

    private protected BaseRepository(FuDeverContext context)
    {
        _dbSet = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity newEntity, CancellationToken cancellationToken)
    {
        // Validate new entity.
        if (Equals(objA: newEntity, objB: default))
        {
            throw new InvalidOperationException();
        }

        await _dbSet.AddAsync(entity: newEntity, cancellationToken: cancellationToken);
    }

    public Task AddRangeAsync(IEnumerable<TEntity> newEntities, CancellationToken cancellationToken)
    {
        // Validate new entity list.
        if (Equals(objA: newEntities, objB: default) || !newEntities.Any())
        {
            throw new InvalidOperationException();
        }

        return _dbSet.AddRangeAsync(entities: newEntities, cancellationToken: cancellationToken);
    }

    public Task<bool> IsFoundBySpecificationsAsync(
        IEnumerable<IBaseSpecification<TEntity>> specifications,
        CancellationToken cancellationToken
    )
    {
        // Validate specification list.
        if (
            Equals(objA: specifications, objB: default)
            || !specifications.Any()
            || !specifications.Any(predicate: specification =>
                !Equals(objA: specification.WhereExpression, objB: default)
            )
        )
        {
            throw new InvalidOperationException();
        }

        IQueryable<TEntity> queryable = _dbSet;

        foreach (var specification in specifications)
        {
            queryable = SpecificationEvaluator.Apply(
                queryable: queryable,
                specification: specification
            );
        }

        return queryable.AnyAsync(cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllBySpecificationsAsync(
        IEnumerable<IBaseSpecification<TEntity>> specifications,
        CancellationToken cancellationToken
    )
    {
        // Validate specification list.
        if (
            Equals(objA: specifications, objB: default)
            || !specifications.Any()
            || !specifications.Any(predicate: specification =>
                !Equals(objA: specification.WhereExpression, objB: default)
            )
            || !specifications.Any(predicate: specification =>
                !Equals(objA: specification.SelectExpression, objB: default)
            )
        )
        {
            throw new InvalidOperationException();
        }

        IQueryable<TEntity> queryable = _dbSet;

        foreach (var specification in specifications)
        {
            queryable = SpecificationEvaluator.Apply(
                queryable: queryable,
                specification: specification
            );
        }

        return await queryable.ToListAsync(cancellationToken: cancellationToken);
    }

    public Task<TEntity> FindBySpecificationsAsync(
        IEnumerable<IBaseSpecification<TEntity>> specifications,
        CancellationToken cancellationToken
    )
    {
        // Validate specification list.
        if (
            Equals(objA: specifications, objB: default)
            || !specifications.Any()
            || !specifications.Any(predicate: specification =>
                !Equals(objA: specification.WhereExpression, objB: default)
            )
            || !specifications.Any(predicate: specification =>
                !Equals(objA: specification.SelectExpression, objB: default)
            )
        )
        {
            throw new InvalidOperationException();
        }

        IQueryable<TEntity> queryable = _dbSet;

        foreach (var specification in specifications)
        {
            queryable = SpecificationEvaluator.Apply(
                queryable: queryable,
                specification: specification
            );
        }

        return queryable.FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<int> BulkUpdateAsync(
        IEnumerable<IBaseSpecification<TEntity>> specifications,
        CancellationToken cancellationToken
    )
    {
        // Validate specification list.
        if (
            Equals(objA: specifications, objB: default)
            || !specifications.Any()
            || !specifications.Any(predicate: specification =>
                !Equals(objA: specification.WhereExpression, objB: default)
            )
            || !specifications.Any(predicate: specification =>
                !Equals(objA: specification.UpdateExpression, objB: default)
            )
        )
        {
            throw new InvalidOperationException();
        }

        IQueryable<TEntity> queryable = _dbSet;

        foreach (var specification in specifications)
        {
            queryable = SpecificationEvaluator.Apply(
                queryable: queryable,
                specification: specification
            );
        }

        return queryable.ExecuteUpdateAsync(
            specifications
                .First(specification =>
                    !Equals(objA: specification.UpdateExpression, objB: default)
                )
                .UpdateExpression,
            cancellationToken: cancellationToken
        );
    }

    public Task<int> BulkDeleteAsync(
        IEnumerable<IBaseSpecification<TEntity>> specifications,
        CancellationToken cancellationToken
    )
    {
        // Validate specification list.
        if (
            Equals(objA: specifications, objB: default)
            || !specifications.Any()
            || !specifications.Any(predicate: specification =>
                !Equals(objA: specification.WhereExpression, objB: default)
            )
        )
        {
            throw new InvalidOperationException();
        }

        IQueryable<TEntity> queryable = _dbSet;

        foreach (var specification in specifications)
        {
            queryable = SpecificationEvaluator.Apply(
                queryable: queryable,
                specification: specification
            );
        }

        return queryable.ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}
