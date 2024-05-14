using FuDever.Domain.Repositories.Major.RestoreMajorByMajorId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Major.RestoreMajorByMajorId.Others;

internal sealed class RestoreMajorByMajorIdRepository : IRestoreMajorByMajorIdRepository
{
    private readonly RestoreMajorByMajorIdStateBag _stateBag;
    private IRestoreMajorByMajorIdCommand _commnad;
    private IRestoreMajorByMajorIdQuery _query;

    internal RestoreMajorByMajorIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRestoreMajorByMajorIdCommand Command
    {
        get { return _commnad ??= new RestoreMajorByMajorIdCommand(stateBag: _stateBag); }
    }

    public IRestoreMajorByMajorIdQuery Query
    {
        get { return _query ??= new RestoreMajorByMajorIdQuery(stateBag: _stateBag); }
    }
}
