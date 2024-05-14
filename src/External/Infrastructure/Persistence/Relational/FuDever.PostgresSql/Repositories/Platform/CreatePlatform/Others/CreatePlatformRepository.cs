using FuDever.Domain.Repositories.Platform.CreatePlatform;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Platform.CreatePlatform.Others;

internal sealed class CreatePlatformRepository : ICreatePlatformRepository
{
    private readonly CreatePlatformStateBag _stateBag;
    private ICreatePlatformQuery _query;
    private ICreatePlatformCommand _command;

    internal CreatePlatformRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public ICreatePlatformQuery Query
    {
        get { return _query ??= new CreatePlatformQuery(stateBag: _stateBag); }
    }

    public ICreatePlatformCommand Command
    {
        get { return _command ??= new CreatePlatformCommand(stateBag: _stateBag); }
    }
}
