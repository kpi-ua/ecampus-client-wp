using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.IO;

namespace eCampus.Core.Helpers
{
    public static class IsolatedStorageHelpers
    {
        public static void SaveToStore<T>(T value, string name)
        {
            IsolatedStorageSettings store = IsolatedStorageSettings.ApplicationSettings;
            if (!store.Contains(name))
            {
                store.Add(name, value);
            }
            else
            {
                store[name] = value;
            }
        }
        public static T OpenFromStore<T>(string name) where T : class, new()
        {
            IsolatedStorageSettings store = IsolatedStorageSettings.ApplicationSettings;
            if (!store.Contains(name))
            {
                return new T();
            }
            else
            {
                return (T)store[name];
            }
        }

    }
}
