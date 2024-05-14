﻿using FuDever.WebApi.HttpResponseMapper.Admin.Others;
using FuDever.WebApi.HttpResponseMapper.Auth.Others;
using FuDever.WebApi.HttpResponseMapper.Entities.Department.Others;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.Others;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.Others;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.Others;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.Others;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.Others;
using FuDever.WebApi.HttpResponseMapper.Entities.Skill.Others;
using FuDever.WebApi.HttpResponseMapper.Entities.User.Others;

namespace FuDever.WebApi.HttpResponseMapper.Others;

/// <summary>
///     Manage all entity http response manager.
/// </summary>
public sealed class HttpResponseMapperManager
{
    private DepartmentHttpResponseManager _departmentHttpResponseManager;
    private HobbyHttpResponseManager _hobbyHttpResponseManager;
    private MajorHttpResponseManager _majorHttpResponseManager;
    private PlatformHttpResponseManager _platformHttpResponseManager;
    private PositionHttpResponseManager _positionHttpResponseManager;
    private RoleHttpResponseManager _roleHttpResponseManager;
    private SkillHttpResponseManager _skillHttpResponseManager;
    private AuthHttpResponseManager _authHttpResponseManager;
    private AdminHttpResponseManager _adminHttpResponseManager;
    private UserHttpResponseManager _userHttpResponseManager;

    internal DepartmentHttpResponseManager Department
    {
        get
        {
            _departmentHttpResponseManager ??= new();

            return _departmentHttpResponseManager;
        }
    }

    internal HobbyHttpResponseManager Hobby
    {
        get
        {
            _hobbyHttpResponseManager ??= new();

            return _hobbyHttpResponseManager;
        }
    }

    internal MajorHttpResponseManager Major
    {
        get
        {
            _majorHttpResponseManager ??= new();

            return _majorHttpResponseManager;
        }
    }

    internal PlatformHttpResponseManager Platform
    {
        get
        {
            _platformHttpResponseManager ??= new();

            return _platformHttpResponseManager;
        }
    }

    internal PositionHttpResponseManager Position
    {
        get
        {
            _positionHttpResponseManager ??= new();

            return _positionHttpResponseManager;
        }
    }

    internal RoleHttpResponseManager Role
    {
        get
        {
            _roleHttpResponseManager ??= new();

            return _roleHttpResponseManager;
        }
    }

    internal SkillHttpResponseManager Skill
    {
        get
        {
            _skillHttpResponseManager ??= new();

            return _skillHttpResponseManager;
        }
    }

    internal AuthHttpResponseManager Auth
    {
        get
        {
            _authHttpResponseManager ??= new();

            return _authHttpResponseManager;
        }
    }

    internal AdminHttpResponseManager Admin
    {
        get
        {
            _adminHttpResponseManager ??= new();

            return _adminHttpResponseManager;
        }
    }

    internal UserHttpResponseManager User
    {
        get
        {
            _userHttpResponseManager ??= new();

            return _userHttpResponseManager;
        }
    }
}
