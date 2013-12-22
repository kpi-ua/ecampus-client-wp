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

		public static string UserID { get; private set; }

		async internal static Task<Result> Auth(string login, string password)
        {
            var json = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("User", "auth") + "?login=" + login + "&password=" + password));
            var result = Result.Parse(json);
            IsolatedStorageHelpers.SaveToStore(result, ResultStoreName);
            return result;
        }

		async internal static Task<MyProfile> GetCurrentUser()
        {
            var result = IsolatedStorageHelpers.OpenFromStore<Result>(ResultStoreName);
			var json = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("User", "GetCurrentUser") + "?sessionId=" + result.Data));
			var data = JsonConvert.DeserializeObject<MyProfile>(json);
			UserID = data.Data.UserAccountId.ToString();
            return data;
        }

        async internal static Task<UserConversations> GetUserConversations()
        {
            var result = IsolatedStorageHelpers.OpenFromStore<Result>(ResultStoreName);
            var json = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("message", "GetUserConversations") + "?sessionId=" + result.Data));
            return JsonConvert.DeserializeObject<UserConversations>(json);
        }

		async internal static Task<UserDialog> GetConversation(string groupId)
		{
			var result = IsolatedStorageHelpers.OpenFromStore<Result>(ResultStoreName);
			var json = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("message", "GetUserConversation") + "?size=100&sessionId=" + result.Data + "&groupid=" + groupId));
			return JsonConvert.DeserializeObject<UserDialog>(json);
		}

		async public static Task SendMessage(string groupId, string text)
		{
			//http://api.ecampus.kpi.ua/message/SendMessage?sessionid=d1754392-8793-4295-a4c8-83eafe170ed1&groupid=2&text=%D0%BB%D0%BE%D0%BB2
			var result = IsolatedStorageHelpers.OpenFromStore<Result>(ResultStoreName);
			await WebHelpers.DownloadString(new Uri(Client.BuildUrl("message", "SendMessage") + "?sessionId=" + result.Data + "&groupid=" + groupId + "&text=" + text));
		}

		async internal static Task<Board> GetActualBB()
		{
			var result = IsolatedStorageHelpers.OpenFromStore<Result>(ResultStoreName);
			var json = await WebHelpers.DownloadString(new Uri(Client.BuildUrl("bulletinboard", "GetActual") + "?sessionId=" + result.Data));
			return JsonConvert.DeserializeObject<Board>(json);
		}
	}
}
