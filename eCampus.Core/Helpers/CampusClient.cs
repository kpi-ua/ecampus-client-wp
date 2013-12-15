using Campus.SDK;
using eCampus.Core.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace eCampus.Core.Helpers
{
    public static class CampusClient
    {
        private const string ResultStoreName = "Result";

        async public static Task<Result> Auth(string login, string password)
        {
            var json = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("User", "auth") + "?login=" + login + "&password=" + password));
            var result = Result.Parse(json);
            IsolatedStorageHelpers.SaveToStore(result, ResultStoreName);
            return result;
        }

        async public static Task<MyProfile> GetCurrentUser()
        {
            var result = IsolatedStorageHelpers.OpenFromStore<Result>(ResultStoreName);
            var json = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("User", "GetCurrentUser") + "?sessionId=" + result.Data));
            return JsonConvert.DeserializeObject<MyProfile>(json);
        }

        async public static Task<UserConversations> GetUserConversations()
        {
            var result = IsolatedStorageHelpers.OpenFromStore<Result>(ResultStoreName);
            var json = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("message", "GetUserConversations") + "?sessionId=" + result.Data));
            return JsonConvert.DeserializeObject<UserConversations>(json);
        }
    }
}
