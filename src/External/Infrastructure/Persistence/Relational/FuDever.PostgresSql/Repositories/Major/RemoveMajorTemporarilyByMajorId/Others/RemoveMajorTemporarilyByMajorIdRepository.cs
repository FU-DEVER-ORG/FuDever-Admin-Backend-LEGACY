using FuDever.Domain.Repositories.Major.RemoveMajorTemporarilyByMajorId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Major.RemoveMajorTemporarilyByMajorId.Others;

internal sealed class RemoveMajorTemporarilyByMajorIdRepository
    : IRemoveMajorTemporarilyByMajorIdRepository
{
    private readonly RemoveMajorTemporarilyByMajorIdStateBag _stateBag;
    private IRemoveMajorTemporarilyByMajorIdCommand _commnad;
    private IRemoveMajorTemporarilyByMajorIdQuery _query;

    internal RemoveMajorTemporarilyByMajorIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemoveMajorTemporarilyByMajorIdCommand Command
    {
        get { return _commnad ??= new RemoveMajorTemporarilyByMajorIdCommand(stateBag: _stateBag); }
    }

    public IRemoveMajorTemporarilyByMajorIdQuery Query
    {
        get { return _query ??= new RemoveMajorTemporarilyByMajorIdQuery(stateBag: _stateBag); }
    }
}
