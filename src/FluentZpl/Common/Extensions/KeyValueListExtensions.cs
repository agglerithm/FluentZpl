using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZplLabels.Common.Extensions
{
    public static class KeyValueListExtensions
    {
        public static bool Exists<T>(this IList<KeyValuePair<string,T>> lst, string key)
        {
           return lst.Where(kv => kv.Key == key).Count() != 0;    
        } 

        public static void SetValue<T>(this IList<KeyValuePair<string,T>> lst, string key, T val)
        {
            var pair = lst.Find(kv => kv.Key == key);
            lst.Remove(pair);
            lst.Add(new KeyValuePair<string, T>(key,val));
        }
    }
}
