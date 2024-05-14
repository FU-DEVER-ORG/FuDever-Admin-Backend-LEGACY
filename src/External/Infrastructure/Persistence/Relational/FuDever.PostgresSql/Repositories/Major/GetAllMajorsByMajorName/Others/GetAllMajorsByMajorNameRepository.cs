using FuDever.Domain.Repositories.Major.GetAllMajorsByMajorName;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Major.GetAllMajorsByMajorName.Others;

internal sealed class GetAllMajorsByMajorNameRepository : IGetAllMajorsByMajorNameRepository
{
    private readonly GetAllMajorsByMajorNameStateBag _stateBag;
    private IGetAllMajorsByMajorNameCommand _commnad;
    private IGetAllMajorsByMajorNameQuery _query;

    internal GetAllMajorsByMajorNameRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IGetAllMajorsByMajorNameCommand Command
    {
        get { return _commnad ??= new GetAllMajorsByMajorNameCommand(); }
    }

    public IGetAllMajorsByMajorNameQuery Query
    {
        get { return _query ??= new GetAllMajorsByMajorNameQuery(stateBag: _stateBag); }
    }
}
