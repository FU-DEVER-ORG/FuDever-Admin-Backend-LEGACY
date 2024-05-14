using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Platform.CreatePlatform;
using FuDever.PostgresSql.Repositories.Platform.CreatePlatform.Others;

namespace FuDever.PostgresSql.Repositories.Platform.CreatePlatform;

internal sealed class CreatePlatformCommand : ICreatePlatformCommand
{
    private readonly CreatePlatformStateBag _stateBag;

    internal CreatePlatformCommand(CreatePlatformStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> CreatePlatformCommandAsync(
        Domain.Entities.Platform newPlatform,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await _stateBag.Platforms.AddAsync(
                entity: newPlatform,
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
