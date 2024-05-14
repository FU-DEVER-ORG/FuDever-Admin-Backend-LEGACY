using FuDever.Domain.Repositories.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.PostgresSql.Data;

namespace FuDever.PostgresSql.Repositories.Auth.ResendUserRegistrationConfirmedEmail.Others;

internal sealed class ResendUserRegistrationConfirmedEmailRepository
    : IResendUserRegistrationConfirmedEmailRepository
{
    private readonly ResendUserRegistrationConfirmedEmailStateBag _stateBag;
    private IResendUserRegistrationConfirmedEmailQuery _query;
    private IResendUserRegistrationConfirmedEmailCommand _command;

    internal ResendUserRegistrationConfirmedEmailRepository(FuDeverContext context)
    {
        _stateBag = new(context: context);
    }

    public IResendUserRegistrationConfirmedEmailQuery Query
    {
        get
        {
            return _query ??= new ResendUserRegistrationConfirmedEmailQuery(stateBag: _stateBag);
        }
    }

    public IResendUserRegistrationConfirmedEmailCommand Command
    {
        get { return _command ??= new ResendUserRegistrationConfirmedEmailCommand(); }
    }
}
