//using ZplLabels.Common.Infrastructure;
//using NHibernate.Dialect;
//using NHibernate.SqlTypes;
//using NHibernate.Type;

namespace ZplLabels.Common
{
    //Greg Banister
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

#pragma warning disable 1591
    public class EnumerationOfInteger
    {
        private readonly int _value;
        private readonly string _text;

        protected EnumerationOfInteger()
        {
        }

        protected EnumerationOfInteger(int value, string displayname)
        {
            _value = value;
            _text = displayname;
        }

        public int Value
        {
            get { return _value; }
        }

        public string Text
        {
            get { return _text; }
        }

        public override string ToString()
        {
            return Text;
        }

 
        protected static IEnumerable<T> GetAll<T>() where T : EnumerationOfInteger, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public static IEnumerable<EnumerationOfInteger> GetAll(Type type)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = Activator.CreateInstance(type);
                yield return (EnumerationOfInteger)info.GetValue(instance);
            }
        }

        public static T FromValue<T>(int value) where T : EnumerationOfInteger, new()
        {
            var matchingItem = parse<T, int>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromText<T>(string displayName) where T : EnumerationOfInteger, new()
        {
            var matchingItem = parse<T, string>(displayName, "display name", item => item.Text  == displayName);
            return matchingItem;
        }

        private static T parse<T, TK>(TK value, string description, Func<T, bool> predicate) where T : EnumerationOfInteger, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public virtual int DefaultValue
        {
            get
            {
                return 1;
            }
        }
    }


}