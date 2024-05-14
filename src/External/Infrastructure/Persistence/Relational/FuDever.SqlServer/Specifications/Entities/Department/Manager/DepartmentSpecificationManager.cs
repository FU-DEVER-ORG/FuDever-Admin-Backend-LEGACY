using System;
using FuDever.Domain.Specifications.Entities.Department;
using FuDever.Domain.Specifications.Entities.Department.Manager;

namespace FuDever.SqlServer.Specifications.Entities.Department.Manager;

internal sealed class DepartmentSpecificationManager : IDepartmentSpecificationManager
{
    private IDepartmentAsNoTrackingSpecification _departmentAsNoTrackingSpecification;
    private IDepartmentNotTemporarilyRemovedSpecification _departmentNotTemporarilyRemovedSpecification;
    private IDepartmentTemporarilyRemovedSpecification _departmentTemporarilyRemovedSpecification;
    private ISelectFieldsFromDepartmentSpecification _selectFieldsFromDepartmentSpecification;
    private IDepartmentNameIsNotDefaultSpecification _departmentNameIsNotDefaultSpecification;
    private IUpdateFieldOfDepartmentSpecification _updateFieldOfDepartmentSpecification;

    public IDepartmentAsNoTrackingSpecification DepartmentAsNoTrackingSpecification
    {
        get
        {
            _departmentAsNoTrackingSpecification ??= new DepartmentAsNoTrackingSpecification();

            return _departmentAsNoTrackingSpecification;
        }
    }

    public IDepartmentNotTemporarilyRemovedSpecification DepartmentNotTemporarilyRemovedSpecification
    {
        get
        {
            _departmentNotTemporarilyRemovedSpecification ??=
                new DepartmentNotTemporarilyRemovedSpecification();

            return _departmentNotTemporarilyRemovedSpecification;
        }
    }

    public IDepartmentTemporarilyRemovedSpecification DepartmentTemporarilyRemovedSpecification
    {
        get
        {
            _departmentTemporarilyRemovedSpecification ??=
                new DepartmentTemporarilyRemovedSpecification();

            return _departmentTemporarilyRemovedSpecification;
        }
    }

    public ISelectFieldsFromDepartmentSpecification SelectFieldsFromDepartmentSpecification
    {
        get
        {
            _selectFieldsFromDepartmentSpecification ??=
                new SelectFieldsFromDepartmentSpecification();

            return _selectFieldsFromDepartmentSpecification;
        }
    }

    public IDepartmentNameIsNotDefaultSpecification DepartmentNameIsNotDefaultSpecification
    {
        get
        {
            _departmentNameIsNotDefaultSpecification ??=
                new DepartmentNameIsNotDefaultSpecification();

            return _departmentNameIsNotDefaultSpecification;
        }
    }

    public IUpdateFieldOfDepartmentSpecification UpdateFieldOfDepartmentSpecification
    {
        get
        {
            _updateFieldOfDepartmentSpecification ??= new UpdateFieldOfDepartmentSpecification();

            return _updateFieldOfDepartmentSpecification;
        }
    }

    public IDepartmentByIdSpecification DepartmentByIdSpecification(Guid departmentId)
    {
        return new DepartmentByIdSpecification(departmentId: departmentId);
    }

    public IDepartmentByNameSpecification DepartmentByNameSpecification(
        string departmentName,
        bool isCaseSensitive
    )
    {
        return new DepartmentByNameSpecification(
            departmentName: departmentName,
            isCaseSensitive: isCaseSensitive
        );
    }
}
