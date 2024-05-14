using FuDever.Domain.Repositories.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Platform.GetAllTemporarilyRemovedPlatforms.Others;

internal sealed class GetAllTemporarilyRemovedPlatformsRepository
    : IGetAllTemporarilyRemovedPlatformsRepository
{
    private readonly GetAllTemporarilyRemovedPlatformsStateBag _stateBag;
    private IGetAllTemporarilyRemovedPlatformsCommand _commnad;
    private IGetAllTemporarilyRemovedPlatformsQuery _query;

    internal GetAllTemporarilyRemovedPlatformsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllTemporarilyRemovedPlatformsCommand Command
    {
        get { return _commnad ??= new GetAllTemporarilyRemovedPlatformsCommand(); }
    }

    public IGetAllTemporarilyRemovedPlatformsQuery Query
    {
        get { return _query ??= new GetAllTemporarilyRemovedPlatformsQuery(stateBag: _stateBag); }
    }
}
