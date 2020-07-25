using System;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using BSRetriever.Interfaces;
using BSRetriever.RetriversAddress.Json.Myinkov;

namespace BSRetriever.RetriversLocation.RetriversLocation
{
    public class RetriverYandex : IRetriverLocation
    {
        public (double lat, double lon) Retrive((string MCC, string MNC, string LAC, string CID) data)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    //
                    var rez = client.DownloadString($"http://mobile.maps.yandex.net/cellid_location/?countrycode={data.MCC}&operatorid={data.MNC}&lac={data.LAC}&cellid={data.CID}");
                    
                    if(rez.Contains("Not found")) return (0, 0);

                    var doc= XElement.Parse(rez)?.Element("coordinates");

                    var lat= doc?.Attribute("latitude")?.Value;
                   var lon= doc?.Attribute("longitude")?.Value;

                   return (double.Parse(lat, System.Globalization.CultureInfo.InvariantCulture),
                       double.Parse(lon, System.Globalization.CultureInfo.InvariantCulture));
                }
            }
            catch (Exception)
            {
                return (0, 0);
            }
            
        }
    }
}