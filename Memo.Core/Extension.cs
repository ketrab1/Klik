using System;
using System.Collections.Generic;

namespace Memo.Core
{
    public static class Extension{

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T obj in enumerable)
            {
                action(obj);
            }
        }
    }
    
}