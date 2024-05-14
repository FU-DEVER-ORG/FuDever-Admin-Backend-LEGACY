using FuDever.Domain.Repositories.Auth.ConfirmUserRegistrationConfirmedEmail;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Auth.ConfirmUserRegistrationConfirmedEmail.Others;

internal sealed class ConfirmUserRegistrationConfirmedEmailRepository
    : IConfirmUserRegistrationConfirmedEmailRepository
{
    private readonly ConfirmUserRegistrationConfirmedEmailStateBag _stateBag;
    private IConfirmUserRegistrationConfirmedEmailQuery _query;
    private IConfirmUserRegistrationConfirmedEmailCommand _command;

    internal ConfirmUserRegistrationConfirmedEmailRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IConfirmUserRegistrationConfirmedEmailQuery Query
    {
        get
        {
            return _query ??= new ConfirmUserRegistrationConfirmedEmailQuery(stateBag: _stateBag);
        }
    }

    public IConfirmUserRegistrationConfirmedEmailCommand Command
    {
        get { return _command ??= new ConfirmUserRegistrationConfirmedEmailCommand(); }
    }
}
