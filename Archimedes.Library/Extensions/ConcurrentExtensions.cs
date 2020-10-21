using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Archimedes.Library.Extensions
{
    public static class ConcurrentExtensions
    {
        public static void AddRange<T>(this ConcurrentBag<T> @this, IEnumerable<T> toAdd)
        {
            foreach (var element in toAdd)
            {
                @this.Add(element);
            }
        }
    }
}