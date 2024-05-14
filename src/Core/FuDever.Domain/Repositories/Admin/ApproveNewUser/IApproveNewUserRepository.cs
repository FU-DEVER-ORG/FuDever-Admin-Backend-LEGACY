namespace FuDever.Domain.Repositories.Admin.ApproveNewUser;

public interface IApproveNewUserRepository
{
    IApproveNewUserCommand Command { get; }

    IApproveNewUserQuery Query { get; }
}
