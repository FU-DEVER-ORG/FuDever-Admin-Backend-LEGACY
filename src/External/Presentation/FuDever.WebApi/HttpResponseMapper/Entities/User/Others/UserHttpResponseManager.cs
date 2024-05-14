using FuDever.WebApi.HttpResponseMapper.Entities.User.GetAllUsers.Others;

namespace FuDever.WebApi.HttpResponseMapper.Entities.User.Others;

/// <summary>
///     Managing all user http responses.
/// </summary>
internal sealed class UserHttpResponseManager
{
    private GetAllUsersHttpResponseManager _getAllUsersHttpResponseManager;

    internal GetAllUsersHttpResponseManager GetAllUsers
    {
        get
        {
            _getAllUsersHttpResponseManager ??= new();

            return _getAllUsersHttpResponseManager;
        }
    }
}
