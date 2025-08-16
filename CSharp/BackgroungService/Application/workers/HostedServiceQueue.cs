using System.Collections.Concurrent;

namespace Application.workers;

public static class HostedServiceQueue
{
    // ConcurrentQueue<T> Class: https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1?view=net-9.0
    public static ConcurrentQueue<long> QueueAccount { get; } = new ConcurrentQueue<long>();
}