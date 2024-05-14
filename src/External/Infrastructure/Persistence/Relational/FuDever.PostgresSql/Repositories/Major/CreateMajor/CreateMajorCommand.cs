using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Major.CreateMajor;
using FuDever.PostgresSql.Repositories.Major.CreateMajor.Others;

namespace FuDever.PostgresSql.Repositories.Major.CreateMajor;

internal sealed class CreateMajorCommand : ICreateMajorCommand
{
    private readonly CreateMajorStateBag _stateBag;

    internal CreateMajorCommand(CreateMajorStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> CreateMajorCommandAsync(
        Domain.Entities.Major newMajor,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await _stateBag.Majors.AddAsync(entity: newMajor, cancellationToken: cancellationToken);

            await _stateBag.Context.SaveChangesAsync(cancellationToken: cancellationToken);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
