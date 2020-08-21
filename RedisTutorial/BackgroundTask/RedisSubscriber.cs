using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace RedisTutorial.BackgroundTask
{
    public class RedisSubscriber : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
        }
    }
}
