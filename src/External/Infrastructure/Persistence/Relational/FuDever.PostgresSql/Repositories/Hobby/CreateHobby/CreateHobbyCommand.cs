using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Hobby.CreateHobby;
using FuDever.PostgresSql.Repositories.Hobby.CreateHobby.Others;

namespace FuDever.PostgresSql.Repositories.Hobby.CreateHobby;

internal sealed class CreateHobbyCommand : ICreateHobbyCommand
{
    private readonly CreateHobbyStateBag _stateBag;

    internal CreateHobbyCommand(CreateHobbyStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> CreateHobbyCommandAsync(
        Domain.Entities.Hobby newHobby,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await _stateBag.Hobbies.AddAsync(
                entity: newHobby,
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
