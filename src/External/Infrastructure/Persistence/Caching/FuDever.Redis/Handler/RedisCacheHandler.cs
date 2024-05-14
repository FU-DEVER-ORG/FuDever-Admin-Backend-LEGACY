﻿using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace FuDever.Redis.Handler;

/// <summary>
///     Implementation of cache handler using redis as storage.
/// </summary>
internal sealed class RedisCacheHandler : ICacheHandler
{
    private readonly IDistributedCache _distributedCache;

    public RedisCacheHandler(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<AppCacheModel<TSource>> GetAsync<TSource>(
        string key,
        CancellationToken cancellationToken
    )
    {
        var cachedValue = await _distributedCache.GetStringAsync(
            key: key,
            token: cancellationToken
        );

        if (string.IsNullOrWhiteSpace(value: cachedValue))
        {
            return AppCacheModel<TSource>.NotFound;
        }

        return JsonConvert.DeserializeObject<TSource>(value: cachedValue);
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken)
    {
        return _distributedCache.RemoveAsync(key: key, token: cancellationToken);
    }

    public Task SetAsync<TSource>(
        string key,
        TSource value,
        DistributedCacheEntryOptions distributedCacheEntryOptions,
        CancellationToken cancellationToken
    )
    {
        return _distributedCache.SetStringAsync(
            key: key,
            value: JsonConvert.SerializeObject(
                value: value,
                formatting: Formatting.None,
                settings: new() { NullValueHandling = NullValueHandling.Ignore }
            ),
            options: distributedCacheEntryOptions,
            token: cancellationToken
        );
    }
}
