using FuDever.Domain.Repositories.Major.GetAllTemporarilyRemovedMajors;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Major.GetAllTemporarilyRemovedMajors.Others;

internal sealed class GetAllTemporarilyRemovedMajorsRepository
    : IGetAllTemporarilyRemovedMajorsRepository
{
    private readonly GetAllTemporarilyRemovedMajorsStateBag _stateBag;
    private IGetAllTemporarilyRemovedMajorsCommand _commnad;
    private IGetAllTemporarilyRemovedMajorsQuery _query;

    internal GetAllTemporarilyRemovedMajorsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllTemporarilyRemovedMajorsCommand Command
    {
        get { return _commnad ??= new GetAllTemporarilyRemovedMajorsCommand(); }
    }

    public IGetAllTemporarilyRemovedMajorsQuery Query
    {
        get { return _query ??= new GetAllTemporarilyRemovedMajorsQuery(stateBag: _stateBag); }
    }
}
