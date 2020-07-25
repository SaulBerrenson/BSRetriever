using System.Net;
using BSRetriever.RetriversAddress.Json.Myinkov;

namespace BSRetriever.Extantions
{
    internal static class MyinakovExtantions
    {
        internal static (double lat, double lon) Retrive(string link)
        {
            using (WebClient client = new WebClient())
            {

                var rez = JsonResponseMyinakov.FromJson(client.DownloadString(link));

                if (rez.Result == 200)
                {
                    return (rez.Data.Lat, rez.Data.Lon);
                }
                return (0, 0);
            }
        }
    }
}