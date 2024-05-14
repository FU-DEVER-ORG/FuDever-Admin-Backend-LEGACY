using FuDever.Domain.Repositories.Major.UpdateMajorByMajorId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Major.UpdateMajorByMajorId.Others;

internal sealed class UpdateMajorByMajorIdRepository : IUpdateMajorByMajorIdRepository
{
    private readonly UpdateMajorByMajorIdStateBag _stateBag;
    private IUpdateMajorByMajorIdCommand _commnad;
    private IUpdateMajorByMajorIdQuery _query;

    internal UpdateMajorByMajorIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IUpdateMajorByMajorIdCommand Command
    {
        get { return _commnad ??= new UpdateMajorByMajorIdCommand(stateBag: _stateBag); }
    }

    public IUpdateMajorByMajorIdQuery Query
    {
        get { return _query ??= new UpdateMajorByMajorIdQuery(stateBag: _stateBag); }
    }
}
