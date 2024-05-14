using FuDever.Domain.Repositories.Major.RemoveMajorPermanentlyByMajorId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Major.RemoveMajorPermanentlyByMajorId.Others;

internal sealed class RemoveMajorPermanentlyByMajorIdRepository
    : IRemoveMajorPermanentlyByMajorIdRepository
{
    private readonly RemoveMajorPermanentlyByMajorIdStateBag _stateBag;
    private IRemoveMajorPermanentlyByMajorIdCommand _commnad;
    private IRemoveMajorPermanentlyByMajorIdQuery _query;

    internal RemoveMajorPermanentlyByMajorIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemoveMajorPermanentlyByMajorIdCommand Command
    {
        get { return _commnad ??= new RemoveMajorPermanentlyByMajorIdCommand(stateBag: _stateBag); }
    }

    public IRemoveMajorPermanentlyByMajorIdQuery Query
    {
        get { return _query ??= new RemoveMajorPermanentlyByMajorIdQuery(stateBag: _stateBag); }
    }
}
