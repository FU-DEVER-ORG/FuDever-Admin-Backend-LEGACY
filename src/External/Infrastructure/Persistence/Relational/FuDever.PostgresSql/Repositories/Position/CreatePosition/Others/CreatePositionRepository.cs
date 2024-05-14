using FuDever.Domain.Repositories.Position.CreatePosition;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Position.CreatePosition.Others;

internal sealed class CreatePositionRepository : ICreatePositionRepository
{
    private readonly CreatePositionStateBag _stateBag;
    private ICreatePositionQuery _query;
    private ICreatePositionCommand _command;

    internal CreatePositionRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public ICreatePositionQuery Query
    {
        get { return _query ??= new CreatePositionQuery(stateBag: _stateBag); }
    }

    public ICreatePositionCommand Command
    {
        get { return _command ??= new CreatePositionCommand(stateBag: _stateBag); }
    }
}
