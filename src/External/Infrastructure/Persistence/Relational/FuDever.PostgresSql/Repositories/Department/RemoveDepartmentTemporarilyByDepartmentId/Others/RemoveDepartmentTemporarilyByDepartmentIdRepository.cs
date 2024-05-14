using FuDever.Domain.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Department.RemoveDepartmentTemporarilyByDepartmentId.Others;

internal sealed class RemoveDepartmentTemporarilyByDepartmentIdRepository
    : IRemoveDepartmentTemporarilyByDepartmentIdRepository
{
    private readonly RemoveDepartmentTemporarilyByDepartmentIdStateBag _stateBag;
    private IRemoveDepartmentTemporarilyByDepartmentIdCommand _commnad;
    private IRemoveDepartmentTemporarilyByDepartmentIdQuery _query;

    internal RemoveDepartmentTemporarilyByDepartmentIdRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IRemoveDepartmentTemporarilyByDepartmentIdCommand Command
    {
        get
        {
            return _commnad ??= new RemoveDepartmentTemporarilyByDepartmentIdCommand(
                stateBag: _stateBag
            );
        }
    }

    public IRemoveDepartmentTemporarilyByDepartmentIdQuery Query
    {
        get
        {
            return _query ??= new RemoveDepartmentTemporarilyByDepartmentIdQuery(
                stateBag: _stateBag
            );
        }
    }
}
