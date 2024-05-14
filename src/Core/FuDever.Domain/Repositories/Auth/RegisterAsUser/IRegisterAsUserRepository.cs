namespace FuDever.Domain.Repositories.Auth.RegisterAsUser;

public interface IRegisterAsUserRepository
{
    IRegisterAsUserCommand Command { get; }

    IRegisterAsUserQuery Query { get; }
}
