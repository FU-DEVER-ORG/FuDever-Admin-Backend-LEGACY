using System;
using System.Collections.Generic;

namespace FuDever.Application.Features.User.GetAllUsers;

/// <summary>
///     Get all users response.
/// </summary>
public sealed class GetAllUsersResponse
{
    public GetAllUsersResponseStatusCode StatusCode { get; init; }

    public IEnumerable<User> FoundUsers { get; init; }

    public sealed class User
    {
        public Guid Id { get; init; }

        public string FullName { get; init; }

        public string Email { get; init; }

        public string Position { get; init; }

        public string Department { get; init; }

        public string Status { get; init; }

        public string AvatarUrl { get; init; }
    }
}
