using FuDever.Domain.Repositories.Major.GetAllMajors;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Major.GetAllMajors.Others;

internal sealed class GetAllMajorsRepository : IGetAllMajorsRepository
{
    private readonly GetAllMajorsStateBag _stateBag;
    private IGetAllMajorsQuery _query;
    private IGetAllMajorsCommand _command;

    internal GetAllMajorsRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllMajorsQuery Query
    {
        get { return _query ??= new GetAllMajorsQuery(stateBag: _stateBag); }
    }

    public IGetAllMajorsCommand Command
    {
        get { return _command ??= new GetAllMajorsCommand(); }
    }
}
