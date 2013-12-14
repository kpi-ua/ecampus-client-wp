using eCampus.Core.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace eCampus.Core.Helpers
{
    public static class CampusAPI
    {
        async public static Task<Campus.SDK.Result> Auth(string login, string password)
        {
            string x = await WebHelpers.DownloadString(new Uri(Campus.SDK.Client.ApiEndpoint + "User/auth?login=" + login + "&password=" + password));
            var ar = JsonConvert.DeserializeObject<Campus.SDK.Result>(x);
            IsolatedStorageHelpers.SaveToStore<Campus.SDK.Result>(ar, "AuthResult");
            return ar;
        }

        async public static Task<MyProfile> GetCurrentUser()
        {
            var ar = IsolatedStorageHelpers.OpenFromStore<Campus.SDK.Result>("AuthResult");
            string x = await eCampus.Core.Helpers.WebHelpers.DownloadString(new Uri(Campus.SDK.Client.ApiEndpoint + "user/GetCurrentUser?sessionId=" + ar.Data));
            return JsonConvert.DeserializeObject<MyProfile>(x);
        }
    }
}
