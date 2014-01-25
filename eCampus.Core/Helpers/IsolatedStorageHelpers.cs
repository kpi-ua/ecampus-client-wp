using System.IO.IsolatedStorage;

namespace eCampus.Core.Helpers
{
	public static class IsolatedStorageHelpers
	{
		public static void SaveToStore<T>(T value, string name)
		{
			var store = IsolatedStorageSettings.ApplicationSettings;

			if (!store.Contains(name))
			{
				store.Add(name, value);
			}
			else
			{
				store[name] = value;
			}
		}

		public static T OpenFromStore<T>(string name)
			where T : class, new()
		{
			var store = IsolatedStorageSettings.ApplicationSettings;

			if (!store.Contains(name))
			{
				return new T();
			}

			return (T)store[name];
		}

		public static bool OpenBooleanFromStore(string name)
		{
			var store = IsolatedStorageSettings.ApplicationSettings;

			if (!store.Contains(name))
			{
				return false;
			}

			return (bool)store[name];
		}

		public static string OpenStringFromStore(string name)
		{
			var store = IsolatedStorageSettings.ApplicationSettings;

			if (!store.Contains(name))
			{
				return "";
			}

			return (string)store[name];
		}
	}
}
