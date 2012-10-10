using System;
using System.Collections.Generic;
using System.Linq;

namespace ZplLabels.Common.Extensions
{
#pragma warning disable 1591
    public static class EnumerableExtensions
    {
        public static T Find<T> (this IEnumerable<T> el, Func<string, T> findMethod, string key )
        {
            return findMethod.Invoke(key);
        }

        public static void AddRange<T>(this IEnumerable<T> lst, IEnumerable<T> arr)
        {
            ((List<T>)lst).AddRange(arr);
        }

        public static IList<T> EagerLoad<T>(this IEnumerable<T> lst)
        {
            return lst.ToList();
        }

//            public static void ForEach<T>(this IEnumerable<T> lst, Action<T> actn)
//            {
//                if (lst == null)
//                    throw new ApplicationException("Cannot call 'ForEach' on a non-existant list!");
//                lst.ToList().ForEach(actn);
//            }

            public static T Find<T>(this IEnumerable<T> lst, Predicate<T> actn)
            {
                return lst.ToList().Find(actn);
            } 

        public static void ForEach<T> (this IList<T> lst, Action<T> action)
            {
                foreach (T item in lst)
                {
                    action(item);
                }

        }

        public static void AddNotNull<T>(this IList<T> lst, T obj) where T : class
        {
            if (obj == null) return;
            lst.Add(obj);
        }

 
  
    }
}