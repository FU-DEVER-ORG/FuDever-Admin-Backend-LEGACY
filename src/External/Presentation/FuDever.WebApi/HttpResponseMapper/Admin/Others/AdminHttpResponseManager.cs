using FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser.Others;
using FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser.Others;

namespace FuDever.WebApi.HttpResponseMapper.Admin.Others;

/// <summary>
///     Handles all HTTP responses for admin.
/// </summary>
internal sealed class AdminHttpResponseManager
{
    private ApproveNewUserHttpResponseManager _approveNewUserHttpResponseManager;
    private RejectNewUserHttpResponseManager _rejectNewUserHttpResponseManager;

    internal ApproveNewUserHttpResponseManager ApproveNewUser
    {
        get
        {
            _approveNewUserHttpResponseManager ??= new();

            return _approveNewUserHttpResponseManager;
        }
    }

    internal RejectNewUserHttpResponseManager RejectNewUser
    {
        get
        {
            _rejectNewUserHttpResponseManager ??= new();

            return _rejectNewUserHttpResponseManager;
        }
    }
}
