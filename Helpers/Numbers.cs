using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Politiq.Helpers
{
    public static class Numbers
    {
        public static int CountOrNull<T>(this IEnumerable<T> source)
        {
            return source == null ? 0 : source.Count();
        }
    }
}