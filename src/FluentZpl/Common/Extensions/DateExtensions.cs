using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZplLabels.Common.Extensions
{
#pragma warning disable 1591
    public static class DateExtensions
    {
        public static DateTime Truncate(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day);
        }
    }
}
