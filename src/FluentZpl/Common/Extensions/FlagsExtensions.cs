using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZplLabels.Common.Extensions
{
#pragma warning disable 1591
    public static class FlagsExtensions
    {
        public static bool Contains(this long flags, long flag)
        {
            return (flag & flags) == flag;
        }
    }
}
