using FuDever.Domain.Repositories.Platform.GetAllPlatforms;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Platform.GetAllPlatforms.Others;

internal sealed class GetAllPlatformsRepository : IGetAllPlatformsRepository
{
    private readonly GetAllPlatformsStateBag _stateBag;
    private IGetAllPlatformsQuery _query;
    private IGetAllPlatformsCommand _command;

    internal GetAllPlatformsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllPlatformsQuery Query
    {
        get { return _query ??= new GetAllPlatformsQuery(stateBag: _stateBag); }
    }

    public IGetAllPlatformsCommand Command
    {
        get { return _command ??= new GetAllPlatformsCommand(); }
    }
}
