namespace FuDever.Domain.Repositories.User.GetAllUsers;

public interface IGetAllUsersRepository
{
    IGetAllUsersCommand Command { get; }

    IGetAllUsersQuery Query { get; }
}
