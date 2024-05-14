using FuDever.Domain.Repositories.Auth.RegisterAsUser;
using FuDever.PostgresSql.Data;
using Microsoft.AspNetCore.Identity;

namespace FuDever.PostgresSql.Repositories.Auth.RegisterAsUser.Others;

internal sealed class RegisterAsUserRepository : IRegisterAsUserRepository
{
    private readonly RegisterAsUserStateBag _stateBag;
    private IRegisterAsUserQuery _query;
    private IRegisterAsUserCommand _command;

    internal RegisterAsUserRepository(
        FuDeverContext context,
        UserManager<Domain.Entities.User> userManager
    )
    {
        _stateBag = new(context: context, userManager: userManager);
    }

    public IRegisterAsUserQuery Query
    {
        get { return _query ??= new RegisterAsUserQuery(stateBag: _stateBag); }
    }

    public IRegisterAsUserCommand Command
    {
        get { return _command ??= new RegisterAsUserCommand(stateBag: _stateBag); }
    }
}
