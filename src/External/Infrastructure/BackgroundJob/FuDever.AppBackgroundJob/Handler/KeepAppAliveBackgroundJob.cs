﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace FuDever.AppBackgroundJob.Handler;

/// <summary>
///     Keep App Alive Background Job.
/// </summary>
public sealed class KeepAppAliveBackgroundJob : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Do work
            Console.WriteLine(value: "App is alive !!");

            await Task.Delay(millisecondsDelay: 120000, cancellationToken: stoppingToken);

            Console.Clear();
        }
    }
}
