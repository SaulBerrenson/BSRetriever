using System.Linq;
using System.Net;
using BSRetriever.Extantions;
using BSRetriever.Interfaces;
using BSRetriever.RetriversAddress.Json.Myinkov;

namespace BSRetriever.RetriversLocation.RetriversLocation
{
    public class RetriverMyinakov : IRetriverLocation
    {
        
        public (double lat, double lon) Retrive((string MCC, string MNC, string LAC, string CID) data)
        {
            return MyinakovExtantions.Retrive($"https://api.mylnikov.org/geolocation/cell?v=1.1&data=open&mcc={data.MCC}&mnc={data.MNC}&lac={data.LAC}&cellid={data.CID}");
        }
    }
}