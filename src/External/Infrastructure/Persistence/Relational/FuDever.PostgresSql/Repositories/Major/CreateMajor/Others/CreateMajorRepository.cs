using FuDever.Domain.Repositories.Major.CreateMajor;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Major.CreateMajor.Others;

internal sealed class CreateMajorRepository : ICreateMajorRepository
{
    private readonly CreateMajorStateBag _stateBag;
    private ICreateMajorQuery _query;
    private ICreateMajorCommand _command;

    internal CreateMajorRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public ICreateMajorQuery Query
    {
        get { return _query ??= new CreateMajorQuery(stateBag: _stateBag); }
    }

    public ICreateMajorCommand Command
    {
        get { return _command ??= new CreateMajorCommand(stateBag: _stateBag); }
    }
}
