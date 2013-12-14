using Campus.SDK;
using eCampus.Core.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace eCampus.Core.Helpers
{
    public static class CampusAPI
    {
        async public static Task<Result> Auth(string login, string password)
        {
            string x = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("User", "auth") + "?login=" + login + "&password=" + password));
            var ar = JsonConvert.DeserializeObject<Result>(x);
            IsolatedStorageHelpers.SaveToStore(ar, "AuthResult");
            return ar;
        }

        async public static Task<MyProfile> GetCurrentUser()
        {
            var ar = IsolatedStorageHelpers.OpenFromStore<Result>("AuthResult");
            string x = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("User", "GetCurrentUser") + "?sessionId=" + ar.Data));
            return JsonConvert.DeserializeObject<MyProfile>(x);
        }
		async public static Task<UserConversations> GetUserConversations()
		{
			var ar = IsolatedStorageHelpers.OpenFromStore<Result>("AuthResult");
			string x = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("message", "GetUserConversations") + "?sessionId=" + ar.Data));
			return JsonConvert.DeserializeObject<UserConversations>(x);
		}
    }
}
