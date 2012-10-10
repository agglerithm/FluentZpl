namespace ZplLabels.Common
{
    //Greg Banister
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
#pragma warning disable 1591
    public class EnumerationOfString<T> where T : EnumerationOfString<T>, new()
    {
        private readonly string _value;
        private readonly string _displayName;



        protected EnumerationOfString(string value, string displayname)
        {
            _value = value;
            _displayName = displayname;
        }

        protected EnumerationOfString() { }


        public string Value
        {
            get { return _value; }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public static IEnumerable<T> GetAll()
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
        
        public static T FromValue(string value) 
        {
            var matchingItem = parse(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromDisplayName(string displayName) 
        {
            var matchingItem = parse(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T parse<K>(K value, string description, Func<T, bool> predicate) 
        {
            var matchingItem = GetAll().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }
    }
}