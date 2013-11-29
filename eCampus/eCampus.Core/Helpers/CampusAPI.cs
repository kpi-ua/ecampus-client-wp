using eCampus.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCampus.Core.Helpers
{
    public static class CampusAPI
    {
        async public static Task<AuthResult> Auth(string login, string password)
        {
            string x = await WebHelpers.DownloadString(new Uri("http://api.ecampus.kpi.ua/User/auth?login=" + login + "&password=" + password));
            AuthResult ar = JsonConvert.DeserializeObject<AuthResult>(x);
            IsolatedStorageHelpers.SaveToStore<AuthResult>(ar, "AuthResult");
            return ar;
        }

        async public static Task<MyProfile> GetCurrentUser()
        {
            AuthResult ar = IsolatedStorageHelpers.OpenFromStore<AuthResult>("AuthResult");
            string x = await eCampus.Core.Helpers.WebHelpers.DownloadString(new Uri("http://api.ecampus.kpi.ua/user/GetCurrentUser?sessionId=" + ar.Data));
            return JsonConvert.DeserializeObject<MyProfile>(x);
        }
    }
}
