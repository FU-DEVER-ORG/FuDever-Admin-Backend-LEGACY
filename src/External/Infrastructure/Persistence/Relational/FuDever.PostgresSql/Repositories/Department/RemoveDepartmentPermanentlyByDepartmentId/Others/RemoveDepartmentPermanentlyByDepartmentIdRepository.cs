using FuDever.Domain.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Department.RemoveDepartmentPermanentlyByDepartmentId.Others;

internal sealed class RemoveDepartmentPermanentlyByDepartmentIdRepository
    : IRemoveDepartmentPermanentlyByDepartmentIdRepository
{
    private readonly RemoveDepartmentPermanentlyByDepartmentIdStateBag _stateBag;
    private IRemoveDepartmentPermanentlyByDepartmentIdCommand _commnad;
    private IRemoveDepartmentPermanentlyByDepartmentIdQuery _query;

    internal RemoveDepartmentPermanentlyByDepartmentIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemoveDepartmentPermanentlyByDepartmentIdCommand Command
    {
        get
        {
            return _commnad ??= new RemoveDepartmentPermanentlyByDepartmentIdCommand(
                stateBag: _stateBag
            );
        }
    }

    public IRemoveDepartmentPermanentlyByDepartmentIdQuery Query
    {
        get
        {
            return _query ??= new RemoveDepartmentPermanentlyByDepartmentIdQuery(
                stateBag: _stateBag
            );
        }
    }
}
