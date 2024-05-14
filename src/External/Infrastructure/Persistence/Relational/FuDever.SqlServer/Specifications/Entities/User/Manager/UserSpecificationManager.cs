using System;
using FuDever.Domain.Specifications.Entities.User;
using FuDever.Domain.Specifications.Entities.User.Manager;

namespace FuDever.SqlServer.Specifications.Entities.User.Manager;

/// <summary>
///     Represent implementation of user specification manager.
/// </summary>
internal sealed class UserSpecificationManager : IUserSpecificationManager
{
    private IUserNotTemporarilyRemovedSpecification _userNotTemporarilyRemovedSpecification;
    private IUserTemporarilyRemovedSpecification _userTemporarilyRemovedSpecification;
    private IUserAsSplitQuerySpecification _userAsSplitQuerySpecification;
    private IUserAsNoTrackingSpecification _userAsNoTrackingSpecification;
    private ISelectFieldsFromUserSpecification _selectFieldsFromUserSpecification;
    private IUpdateFieldOfUserSpecification _updateFieldOfUserSpecification;

    public IUserNotTemporarilyRemovedSpecification UserNotTemporarilyRemovedSpecification
    {
        get
        {
            _userNotTemporarilyRemovedSpecification ??=
                new UserNotTemporarilyRemovedSpecification();

            return _userNotTemporarilyRemovedSpecification;
        }
    }

    public IUserAsNoTrackingSpecification UserAsNoTrackingSpecification
    {
        get
        {
            _userAsNoTrackingSpecification ??= new UserAsNoTrackingSpecification();

            return _userAsNoTrackingSpecification;
        }
    }

    public ISelectFieldsFromUserSpecification SelectFieldsFromUserSpecification
    {
        get
        {
            _selectFieldsFromUserSpecification ??= new SelectFieldsFromUserSpecification();

            return _selectFieldsFromUserSpecification;
        }
    }

    public IUserAsSplitQuerySpecification UserAsSplitQuerySpecification
    {
        get
        {
            _userAsSplitQuerySpecification ??= new UserAsSplitQuerySpecification();

            return _userAsSplitQuerySpecification;
        }
    }

    public IUserTemporarilyRemovedSpecification UserTemporarilyRemovedSpecification
    {
        get
        {
            _userTemporarilyRemovedSpecification ??= new UserTemporarilyRemovedSpecification();

            return _userTemporarilyRemovedSpecification;
        }
    }

    public IUpdateFieldOfUserSpecification UpdateFieldOfUserSpecification
    {
        get
        {
            _updateFieldOfUserSpecification ??= new UpdateFieldOfUserSpecification();

            return _updateFieldOfUserSpecification;
        }
    }

    public IUserByIdSpecification UserByIdSpecification(Guid userId)
    {
        return new UserByIdSpecification(userId: userId);
    }

    public IUserByEmailSpecification UserByEmailSpecification(string email)
    {
        return new UserByEmailSpecification(email: email);
    }

    public IUserByPhoneNumberSpecification UserByPhoneNumberSpecification(string phoneNumber)
    {
        return new UserByPhoneNumberSpecification(phoneNumber: phoneNumber);
    }

    public IUserByUsernameSpecification UserByUsernameSpecification(string username)
    {
        return new UserByUsernameSpecification(username: username);
    }

    public IUserNotByIdSpecification UserNotByIdSpecification(Guid userId)
    {
        return new UserNotByIdSpecification(userId: userId);
    }

    public IUserByPositionIdSpecification UserByPositionIdSpecification(Guid positionId)
    {
        return new UserByPositionIdSpecification(positionId: positionId);
    }

    public IUserByMajorIdSpecification UserByMajorIdSpecification(Guid majorId)
    {
        return new UserByMajorIdSpecification(majorId: majorId);
    }

    public IUserByDepartmentIdSpecification UserByDepartmentIdSpecification(Guid departmentId)
    {
        return new UserByDepartmentIdSpecification(departmentId: departmentId);
    }

    public IUserByNormalizedEmailSpecification UserByNormalizedEmailSpecification(string userEmail)
    {
        return new UserByNormalizedEmailSpecification(userEmail: userEmail);
    }

    public IUserByNormalizedUsernameSpecification UserByNormalizedUsernameSpecification(
        string username
    )
    {
        return new UserByNormalizedUsernameSpecification(username: username);
    }
}
