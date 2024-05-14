namespace FuDever.Domain.Repositories.Admin.RejectNewUser;

public interface IRejectNewUserRepository
{
    IRejectNewUserCommand Command { get; }

    IRejectNewUserQuery Query { get; }
}
