using System;
using BSRetriever.Extantions;
using BSRetriever.Interfaces;

namespace BSRetriever.RetriversLocation.RetriversLocation
{
    public class RetriverMyinakovWifi : IWifiRetriverLocation
    {
        public (double lat, double lon) Retrive(string bssid)
        {
            return MyinakovExtantions.Retrive(
                $"https://api.mylnikov.org/geolocation/wifi?v=1.1&data=open&bssid={bssid.Replace(":", String.Empty).ToUpper()}");
        }
    }
}