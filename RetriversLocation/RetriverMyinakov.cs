using System.Linq;
using System.Net;
using BSRetriever.Interfaces;
using BSRetriever.RetriversAddress.Json.Myinkov;

namespace BSRetriever.RetriversLocation.RetriversLocation
{
    public class RetriverMyinakov : IRetriverLocation
    {
        
        public (double lat, double lon) Retrive((string MCC, string MNC, string LAC, string CID) data)
        {
            using (WebClient client = new WebClient())
            {

                var rez = JsonResponseMyinakov.FromJson(client.DownloadString($"https://api.mylnikov.org/geolocation/cell?v=1.1&data=open&mcc={data.MCC}&mnc={data.MNC}&lac={data.LAC}&cellid={data.CID}"));

                if (rez.Result == 200)
                {
                    return (rez.Data.Lat, rez.Data.Lon);
                }
                return (0, 0);
            }
        }
    }
}