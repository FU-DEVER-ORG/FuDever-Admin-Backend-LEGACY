using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.Repositories.Department.CreateDepartment;
using FuDever.PostgresSql.Repositories.Department.CreateDepartment.Others;

namespace FuDever.PostgresSql.Repositories.Department.CreateDepartment;

internal sealed class CreateDepartmentCommand : ICreateDepartmentCommand
{
    private readonly CreateDepartmentStateBag _stateBag;

    internal CreateDepartmentCommand(CreateDepartmentStateBag stateBag)
    {
        _stateBag = stateBag;
    }

    public async Task<bool> CreateDepartmentCommandAsync(
        Domain.Entities.Department newDepartment,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await _stateBag.Departments.AddAsync(
                entity: newDepartment,
                cancellationToken: cancellationToken
            );

            await _stateBag.Context.SaveChangesAsync(cancellationToken: cancellationToken);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
