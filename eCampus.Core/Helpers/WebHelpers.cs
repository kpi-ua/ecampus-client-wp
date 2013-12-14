using System;
using System.Net;
using System.Threading.Tasks;

namespace eCampus.Core.Helpers
{
    public static class WebHelpers
    {
        public static Task<string> DownloadString(Uri url)
        {
            var tcs = new TaskCompletionSource<string>();
            var webClient = new WebClient();

            webClient.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(e.Result);
            };

            webClient.DownloadStringAsync(url);
            return tcs.Task;
        }
    }
}
