using System;
using BSRetriever.Interfaces;

namespace BSRetriever.RetriversLocation.RetriversLocation
{
    public class RetriverYandexWifi : IWifiRetriverLocation
    {
        public (double lat, double lon) Retrive(string bssid)
        {
            return YandexExtantions.Get(
                $"http://mobile.maps.yandex.net/cellid_location/?wifinetworks={bssid.Replace(":", String.Empty).ToUpper()}:-1");
        }
    }
}