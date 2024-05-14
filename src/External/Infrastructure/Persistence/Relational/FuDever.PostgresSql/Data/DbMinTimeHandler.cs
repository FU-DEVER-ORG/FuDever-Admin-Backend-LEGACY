using System;
using FuDever.Application.Shared.Data;
using FuDever.PostgresSql.Commons;

namespace FuDever.PostgresSql.Data;

/// <summary>
///     Implementation of database min date time handler.
/// </summary>
internal sealed class DbMinTimeHandler : IDbMinTimeHandler
{
    public DateTime Get()
    {
        return CommonConstant.DbDefaultValue.MIN_DATE_TIME;
    }
}
