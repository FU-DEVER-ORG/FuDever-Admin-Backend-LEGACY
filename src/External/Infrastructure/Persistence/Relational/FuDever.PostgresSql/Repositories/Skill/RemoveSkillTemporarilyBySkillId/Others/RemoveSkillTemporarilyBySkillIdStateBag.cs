﻿using FuDever.PostgresSql.Data;
using Microsoft.EntityFrameworkCore;

namespace FuDever.PostgresSql.Repositories.Skill.RemoveSkillTemporarilyBySkillId.Others;

internal sealed class RemoveSkillTemporarilyBySkillIdStateBag
{
    private DbSet<Domain.Entities.Skill> _skills;
    private DbSet<Domain.Entities.RefreshToken> _refreshTokens;
    private DbSet<Domain.Entities.UserDetail> _userDetails;

    internal DbSet<Domain.Entities.Skill> Skills
    {
        get { return _skills ??= Context.Set<Domain.Entities.Skill>(); }
    }

    internal DbSet<Domain.Entities.RefreshToken> RefreshTokens
    {
        get { return _refreshTokens ??= Context.Set<Domain.Entities.RefreshToken>(); }
    }

    internal DbSet<Domain.Entities.UserDetail> UserDetails
    {
        get { return _userDetails ??= Context.Set<Domain.Entities.UserDetail>(); }
    }

    internal FuDeverContext Context { get; }

    internal RemoveSkillTemporarilyBySkillIdStateBag(FuDeverContext context)
    {
        Context = context;
    }
}
