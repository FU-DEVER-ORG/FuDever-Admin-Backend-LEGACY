using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Position.CreatePosition;
using FuDever.PostgresSql.Repositories.Position.CreatePosition.Others;

namespace FuDever.PostgresSql.Repositories.Position.CreatePosition;

internal sealed class CreatePositionCommand : ICreatePositionCommand
{
    private readonly CreatePositionStateBag _stateBag;

    internal CreatePositionCommand(CreatePositionStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> CreatePositionCommandAsync(
        Domain.Entities.Position newPosition,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await _stateBag.Positions.AddAsync(
                entity: newPosition,
                cancellationToken: cancellationToken
            );

            await _stateBag.Context.SaveChangesAsync(cancellationToken: cancellationToken);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
