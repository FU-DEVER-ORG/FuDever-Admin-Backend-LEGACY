using FuDever.Domain.Repositories.User.GetAllUsers;

namespace FuDever.Domain.Repositories.User.Manager;

public interface IUserFeatureRepository
{
    IGetAllUsersRepository GetAllUsers { get; }
}
